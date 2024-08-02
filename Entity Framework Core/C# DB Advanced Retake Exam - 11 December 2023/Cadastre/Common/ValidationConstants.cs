namespace Cadastre.Common
{
    public class ValidationConstants
    {
        //District
        public const int DistrictNameMinLength = 2;
        public const int DistrictNameMaxLength = 80;
        public const int DistrictPostalCodeMaxLength = 8;

        //Property
        public const int PropertyIdentifierMinLength = 16;
        public const int PropertyIdentifierMaxLength = 20;
        public const int PropertyAreaMinLength = 0;
        public const int PropertyAreaMaxLength = int.MaxValue;
        public const int PropertyDetailsMinLength = 5;
        public const int PropertyDetailsMaxLength = 500;
        public const int PropertyAddressMinLength = 5;
        public const int PropertyAddressMaxLength = 200;

        //Citizen
        public const int CitizenFirstNameMaxLength = 30;
        public const int CitizenLastNameMaxLength = 30;
    }
}
