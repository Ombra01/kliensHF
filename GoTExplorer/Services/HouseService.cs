using GoTExplorer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoTExplorer.Services
{
    class HouseService
    {
        private readonly Uri serverUrl = new Uri("https://anapioficeandfire.com");

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<List<House>> GetHousesAsync(int pageNumber)
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses?page=" + pageNumber));
        }

        public async Task<House> GetHouseAsync(int id)
        {
            return await GetAsync<House>(new Uri(serverUrl, $"api/houses/{id}"));
        }

        public async Task<List<House>> GetHouseAsync(string name)
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, $"api/houses?name=" + name.Replace(' ', '+')));
        }
    }
}
