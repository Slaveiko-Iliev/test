
namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        private T _value;

        public Box (T value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return $"{_value.GetType()}: {_value}";
        }
    }
}
