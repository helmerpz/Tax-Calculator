using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Models
{
    public class Order
    {
        public Address fromAddr { get; set; }
        public Address toAddr { get; set; }
        public decimal amount { get; set; }
        public decimal shipping { get; set; }
        // Flatten From & To address properties below, required by Tax Jar Api (Json structure)
        public string from_street { get { return fromAddr?.street; } set { fromAddr.street = value; } }
        public string from_city { get { return fromAddr?.city; } set { fromAddr.city = value; } }
        public string from_state { get { return fromAddr?.state; } set { fromAddr.state = value; } }
        public string from_country { get { return fromAddr?.country; } set { fromAddr.country = value; }  }
        public string from_zip { get { return fromAddr?.zip; } set { fromAddr.zip = value; } }
        public string to_street { get { return toAddr?.street; } set { toAddr.street = value; } }
        public string to_city { get { return toAddr?.city; } set { toAddr.city = value; } }
        public string to_state { get { return toAddr?.state; } set { toAddr.state = value; } }
        public string to_country { get { return toAddr?.country; } set { toAddr.country = value; } }
        public string to_zip { get { return toAddr?.zip; } set { toAddr.zip = value; } }

        public Order()
        {
            fromAddr = new Address();
            toAddr = new Address();
        }
    }
}
