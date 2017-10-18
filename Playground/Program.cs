using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    using Attributes;

    class Program
    {
        static void Main(string[] args)
        {
            // attribute reflection
            // class attribute
            System.Reflection.MemberInfo memberInfo = typeof(Car);
            foreach (var attribute in memberInfo.GetCustomAttributes(false))
            {
                var customAttribute = attribute as CountryAttribute;
                Console.WriteLine(customAttribute.Country);
            }
            Console.WriteLine("===");

            // method attribute
            System.Reflection.MethodInfo[] methodsInfo = typeof(Car).GetMethods();
            foreach (var methodInfo in methodsInfo)
            {
                foreach (var attribute in methodInfo.GetCustomAttributes(false))
                {
                    var fastAttribute = attribute as FastAttribute;
                    if (fastAttribute != null)
                        Console.WriteLine("fast attribute found on method: " + attribute.ToString());
                }
            }

            // property attribute
            System.Reflection.PropertyInfo[] propertiesInfo = typeof(Car).GetProperties();
            foreach (var propertyInfo in propertiesInfo)
            {
                foreach (var attribute in propertyInfo.GetCustomAttributes(false))
                {
                    var unsureAttribute = attribute as UnsureAttribute;
                    if (unsureAttribute != null)
                        Console.WriteLine("unsure attribute found on property: " + attribute.ToString());
                }
            }

            Console.ReadLine();
        }
    }
}
