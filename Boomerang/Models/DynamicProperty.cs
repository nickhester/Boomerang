using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boomerang.Models
{
    public class DynamicProperty
    {
        [Key]
        public int MyId { get; set; }
        public string MyName { get; set; }
    }
}