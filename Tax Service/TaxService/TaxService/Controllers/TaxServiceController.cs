using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxService.Models;

namespace TaxService.Controllers
{
    [ApiController]
   
    public class TaxServiceController : ControllerBase
    {
        private readonly ILogger<TaxServiceController> _logger;
        private ITaxCalculator _taxCalculator;

        public TaxServiceController(ILogger<TaxServiceController> logger, ITaxCalculator taxCalculator)
        {
            _logger = logger;
            _taxCalculator = taxCalculator;
        }

        [HttpGet]
        [Route("[controller]/getrate")]
        [Route("[controller]/getrate/{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> GetRate(string zipCode)
        {
            // Zip code (location) required, we return bad request if no zip code requested
            if (string.IsNullOrEmpty(zipCode))
                return StatusCode(StatusCodes.Status400BadRequest, "Zip code is required.");

            Address addr = new Address() { zip = zipCode };
            decimal taxRate = await _taxCalculator.GetTaxRate(addr);

            return Ok(taxRate);
        }

        [HttpPost]
        [Route("[controller]/calculatetax")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> CalculateTax([FromBody] Order myOrder)
        {
            if(string.IsNullOrEmpty(myOrder.from_country))
                return StatusCode(StatusCodes.Status400BadRequest, "From country is required.");
            if (string.IsNullOrEmpty(myOrder.from_state))
                return StatusCode(StatusCodes.Status400BadRequest, "From state is required.");
            if (string.IsNullOrEmpty(myOrder.from_zip))
                return StatusCode(StatusCodes.Status400BadRequest, "From zip is required.");

            decimal taxAmount = await _taxCalculator.CalculateTaxes(myOrder);
            return Ok(taxAmount);
        }
    }
}
