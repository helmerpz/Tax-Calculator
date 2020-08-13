using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Models
{
    // Class to deserialize response from Tax Jar API 
    public class CalculateResponse
    {
        public TaxCalculation tax;
        public class TaxCalculation
        {
            public decimal amount_to_collect { get; set; }
        }
    }
}
