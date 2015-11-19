using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency
    {

        public Currency(string symbol, double value, string date)
        {
            this.symbol = symbol;
            this.value = value;
            this.date = date;
        }

        public Currency(string symbol, double value){
            this.symbol = symbol;
            this.value = value;
        }

        private string _symbol;
        public string symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        private double _value;
        public double value
        {
            get { return _value; }
            set { _value = value; }
        }

        private string _date;
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }

        Dictionary<string, string> longNames = new Dictionary<string, string>()
        {
            {"USD","US Dollars"} ,{"JPY","Japanese Yen"} ,{"BGN","Bulgarian Lev"} ,{"CZK","Czech Republic Koruna"} ,{"DKK","Danish Krone"} ,{"GBP","Great British Pound"} ,
            {"HUF","Hungarian Forint"} ,{"PLN","Polish Zloty"} ,{"RON","Romanian leu"} ,{"SEK","Swedish Krona"} ,{"CHF","Swiss Francs"} ,{"NOK","Norwegian Krone"} ,
            {"HRK","Croatian Kuna"} ,{"RUB","Russian Ruble"} ,{"TRY","Turkish Lira"} ,{"AUD","Australian Dollars"} ,{"BRL","Brazilian Real"} ,{"CAD","Canadian Dollars"} ,
            {"CNY","Chinese Yuan"} ,{"HKD","Hong Kong Dollars"} ,{"IDR","Indonesian Rupiah"} ,{"ILS","Israel New Sheqel"} ,{"INR","Indian Rupee"} ,{"KRW","South Korean Won"} ,
            {"MXN","Mexican Peso"} ,{"MYR","Malaysian Ringgit"} ,{"NZD","New Zealand Dollars"} ,{"PHP","Philippine Peso"} ,{"SGD","Singapore Dollar"} ,{"THB","Thai Baht"} ,{"ZAR","South African Rand"} ,{"EUR","Euros"}
        };
    }
}
