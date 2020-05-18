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
    class CharacterService
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

        public async Task<List<Character>> GetCharactersAsync(int pageNumber)
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters?page=" + pageNumber));
        }

        public async Task<Character> GetCharacterAsync(int id)
        {
            return await GetAsync<Character>(new Uri(serverUrl, $"api/characters/{id}"));
        }

        public async Task<List<Character>> GetCharacterAsync(string name)
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, $"api/characters?name=" + name.Replace(' ', '+')));
        }
    }
}