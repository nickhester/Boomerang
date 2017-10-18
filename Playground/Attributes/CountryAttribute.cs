using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Playground.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CountryAttribute : Attribute
    {
        public string Country;
        public CountryAttribute(string text)
        {
            Country = text;
        }
    }
}