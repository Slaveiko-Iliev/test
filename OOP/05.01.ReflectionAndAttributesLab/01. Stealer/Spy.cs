using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type typeOfClass = Type.GetType(className);

            var testInstance = Activator.CreateInstance(typeOfClass);

            StringBuilder sb = new();
            sb.AppendLine($"Class under investigation: {className}");



            foreach (var fieldName in fields)
            {
                FieldInfo field = typeOfClass.GetField(fieldName, (BindingFlags)60);

                string fieldValue = (string)field.GetValue(testInstance);

                sb.AppendLine($"{field.Name} = {fieldValue}");

                //foreach (var fieldInfo in fieldsInfo)
                //{
                //    string fieldValue = (string)fieldInfo.GetValue(null);

                //    
                //}

            }

            return sb.ToString().TrimEnd();
        }
    }
}
