namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToArray();

            ;
            var creatorDtosToexport = creators.Select(c => new ExportCreatorDto()
            {
                BoardgamesCount = c.Boardgames.Count,
                CreatorName = $"{c.FirstName} {c.LastName}",
                Boardgames = c.Boardgames.Select(b => new ExportBoardgameDto()
                {
                    BoardgameName = b.Name,
                    BoardgameYearPublished = b.YearPublished
                })
                .OrderBy(b => b.BoardgameName)
                .ToArray()
            })
            .OrderByDescending(c => c.Boardgames.Length)
            .ThenBy(c => c.CreatorName)
            .ToArray();

            return xmlHelper.Serialize(creatorDtosToexport, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            ExportSellerDto[] sellerDtos = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year
                                                        && bs.Boardgame.Rating <= rating))
                .Select(s => new ExportSellerDto()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year
                              && bs.Boardgame.Rating <= rating)
                    .Select(bs => new BoardgameDto()
                    {
                        Name = bs.Boardgame.Name,
                        Rating = bs.Boardgame.Rating,
                        Mechanics = bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(bs => bs.Rating)
                    .ThenBy(bs => bs.Name)
                    .ToArray()
                })
                .OrderByDescending(bs => bs.Boardgames.Length)
                .ThenBy(bs => bs.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellerDtos, Formatting.Indented);
        }
    }
}