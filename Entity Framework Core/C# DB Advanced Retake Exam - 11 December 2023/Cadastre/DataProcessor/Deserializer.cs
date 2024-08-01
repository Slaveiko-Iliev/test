namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using System.ComponentModel.DataAnnotations;

    using Cadastre.Utilities;
    using Cadastre.DataProcessor.ImportDtos;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportDistrictDto), "Districts");

            using StringReader stringReader = new StringReader(xmlDocument);

            ImportDistrictDto[] districtDtos = (ImportDistrictDto[])xmlSerializer.Deserialize(stringReader);

            return "";
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
