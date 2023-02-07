using Caliburn.Micro;
using CryptoTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTest.ViewModels
{
    public class ShellViewModel : Screen
    {
        private BindableCollection<CurrencyModel> _currencyList = new BindableCollection<CurrencyModel>();
        public BindableCollection<CurrencyModel> CurrencyList
        {
            get { return _currencyList; }
            set { _currencyList = value;}                
        }

        public async Task<IEnumerable<CurrencyModel>> GetDataFromApi()
        {
            string apiUrl = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                   
                    var data = JsonConvert.DeserializeObject<List<CurrencyModel>>(content);
                    CurrencyList = new BindableCollection<CurrencyModel>(data);  
                }
                return CurrencyList;
            }
        }
    }
}
