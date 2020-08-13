using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Models
{
    // Class needed to desesiralize Json response from Tax Jar Api (taxrate endpoint)
    public class RateResponse
    {
        public Rate rate;

        public class Rate
        {
            public string zip { get; set; }
            public string state { get; set; }
            public decimal state_rate { get; set; }
            public string county { get; set; }
            public decimal county_rate { get; set; }
            public string city { get; set; }
            public decimal city_rate { get; set; }
            public decimal combined_district_rate { get; set; }
            public decimal combined_rate { get; set; }
            public bool freight_taxable { get; set; }
        }
    }
}
