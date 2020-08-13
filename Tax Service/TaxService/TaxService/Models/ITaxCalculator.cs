using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Models
{
    public interface ITaxCalculator
    {
        Task<decimal> GetTaxRate(Address addr);
        Task<decimal> CalculateTaxes(Order order);
    }
}
