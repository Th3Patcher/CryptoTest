using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTest.Models
{
    public class CurrencyModel
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public double current_price { get; set; }
        public double price_change_percentage_24h { get; set; }
        public double market_cap { get; set; }
    }
}
