namespace ValidationAttributes.Utils
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _minValue;
        private int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override bool IsValid(object obj) => _minValue <= (int)obj && (int)obj <= _maxValue;
    }
}
