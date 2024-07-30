using Invoices.Data.Models.Enums;

namespace Invoices.Common
{
    public static class ValidationConstants
    {
        //Product
        public const string ProductPriceMinValue = "5.00";
        public const string ProductPriceMaxValue = "1000.00";
        public const int ProductCategoryTypeMinValue = (int)CategoryType.ADR;
        public const int ProductCategoryTypeMaxValue = (int)CategoryType.Tyres;

        //Invoice
        public const int InvoiceCurrencyTypeMinValue = (int)CurrencyType.BGN;
        public const int InvoiceCurrencyTypeMaxValue = (int)CurrencyType.USD;
    }
}
