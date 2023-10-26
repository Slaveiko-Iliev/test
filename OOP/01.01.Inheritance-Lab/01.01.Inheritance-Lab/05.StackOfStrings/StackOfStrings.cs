

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public Stack<string> AddRange(List<string> list)
        {
            foreach (var str in list)
            {
                Push(str);
            }
            return this;
        }
    }
}
