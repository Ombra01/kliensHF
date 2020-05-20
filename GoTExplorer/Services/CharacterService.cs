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
    ///     Service responsible to get the data of characters.
    /// </summary>
    class CharacterService
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
        ///     Method to get a list of characters from the server. 10 characters will be returned per call.
        /// </summary>
        /// <param name="pageNumber">page number for paging.</param>
        public async Task<List<Character>> GetCharactersAsync(int pageNumber)
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters?page=" + pageNumber));
        }

        /// <summary>
        ///     Method to get a single character from the server. The character is identified by its ID.
        /// </summary>
        /// <param name="id">id of the target character.</param>
        public async Task<Character> GetCharacterAsync(int id)
        {
            return await GetAsync<Character>(new Uri(serverUrl, $"api/characters/{id}"));
        }

        /// <summary>
        ///     Method to get a single character from the server. The character is identified by its name.
        /// </summary>
        /// <param name="name">name of the target character.</param>
        public async Task<List<Character>> GetCharacterAsync(string name)
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, $"api/characters?name=" + name.Replace(' ', '+')));
        }
    }
}