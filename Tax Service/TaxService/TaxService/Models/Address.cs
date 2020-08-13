using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Models
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zip { get; set; }

    }
}
