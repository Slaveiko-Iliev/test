namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportCtreatorDto[] importCreatorDtos = xmlHelper.Deserialize<ImportCtreatorDto[]>(xmlString, "Creators");

            StringBuilder sb = new StringBuilder();

            List<Creator> creators = new List<Creator>();

            foreach (var icd in importCreatorDtos)
            {
                if (!IsValid(icd))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = icd.FirstName,
                    LastName = icd.LastName
                };

                foreach (var b in icd.Boardgames)
                {
                    if (!IsValid(b))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = b.Name,
                        Rating = b.Rating,
                        YearPublished = b.YearPublished,
                        CategoryType = (CategoryType)b.CategoryType,
                        Mechanics = b.Mechanics
                    };

                    creator.Boardgames.Add(boardgame);
                }
                creators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }
            //return sb.ToString().TrimEnd();

            context.Creators.AddRange(creators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            ImportSellerDto[] sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            var sb = new StringBuilder();
            List<Seller> sellers = new List<Seller>();

            int[] validGamesIds = context.Boardgames
                .Select(x => x.Id)
                .ToArray();

            foreach (var sd in sellerDtos)
            {
                if (!IsValid(sd))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller newSeller = new Seller()
                {
                    Name = sd.Name,
                    Address = sd.Address,
                    Country = sd.Country,
                    Website = sd.Website
                };

                foreach (var b in sd.Boardgames.Distinct())
                {
                    if (!validGamesIds.Any(vgi => vgi == b))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller newBoardgameSeller = new BoardgameSeller()
                    {
                        Seller = newSeller,
                        BoardgameId = b
                    };

                    newSeller.BoardgamesSellers.Add(newBoardgameSeller);
                }
                sellers.Add(newSeller);

                sb.AppendLine(string.Format(SuccessfullyImportedSeller, newSeller.Name, newSeller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(sellers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
