﻿using System.Reflection;
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
            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new();

            Type typeOfClass = Type.GetType(className);

            FieldInfo[] allFields = typeOfClass.GetFields((BindingFlags)60);

            foreach (FieldInfo field in allFields)
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            PropertyInfo[] allProperties = typeOfClass.GetProperties((BindingFlags)60);

            MethodInfo[] classPublicMethod = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethod = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo method in classNonPublicMethod.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classPublicMethod.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }




            return sb.ToString().TrimEnd();
        }
    }
}
