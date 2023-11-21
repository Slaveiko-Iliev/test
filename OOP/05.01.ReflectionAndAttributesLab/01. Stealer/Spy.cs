using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            StringBuilder sb = new();
            sb.AppendLine($"Class under investigation: {className}");

            Type typeOfClass = Type.GetType(className);

            foreach (var field in fields)
            {
                FieldInfo[] fieldsInfo = typeOfClass.GetFields((BindingFlags)60);

                foreach (var fieldInfo in fieldsInfo)
                {
                    string fieldValue = (string)fieldInfo.GetValue(null);

                    sb.AppendLine($"{fieldInfo.Name} = {fieldValue}");
                }

            }

            return sb.ToString().TrimEnd();
        }
    }
}
