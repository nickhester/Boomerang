using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    using Attributes;

    [Country("Japanese")]
    class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        [Unsure]
        public int year { get; set; }

        [Fast]
        public int WhatYearWasCarMade()
        {
            return year;
        }
    }
}
