using Invoices.Data.Models.Enums;

namespace Invoices.Common
{
    public static class ValidationConstants
    {
        public const int ProductCategoryTypeMinValue = (int)CategoryType.ADR;
        public const int ProductCategoryTypeMaxValue = (int)CategoryType.Tyres;
    }
}
