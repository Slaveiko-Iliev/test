using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type typeOfObj = obj.GetType();

            PropertyInfo[] properties = typeOfObj.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                IEnumerable<MyValidationAttribute> attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(propertyInfo.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
