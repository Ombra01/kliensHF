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
    /// <summary>
    ///     Service responsible to get the data of houses.
    /// </summary>
    class HouseService
    {
        private readonly Uri serverUrl = new Uri("https://anapioficeandfire.com");

        /// <summary>
        ///     Async call to the server in order to retrieve the data.
        /// </summary>
        /// <param name="uri">server uri.</param>
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

        /// <summary>
        ///     Method to get a list of houses from the server. 10 houses will be returned per call.
        /// </summary>
        /// <param name="pageNumber">page number for paging.</param>
        public async Task<List<House>> GetHousesAsync(int pageNumber)
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses?page=" + pageNumber));
        }

        /// <summary>
        ///     Method to get a single house from the server. The house is identified by its ID.
        /// </summary>
        /// <param name="id">id of the target house.</param>
        public async Task<House> GetHouseAsync(int id)
        {
            return await GetAsync<House>(new Uri(serverUrl, $"api/houses/{id}"));
        }

        /// <summary>
        ///     Method to get a single house from the server. The house is identified by its name.
        /// </summary>
        /// <param name="name">name of the target house.</param>
        public async Task<List<House>> GetHouseAsync(string name)
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, $"api/houses?name=" + name.Replace(' ', '+')));
        }
    }
}
