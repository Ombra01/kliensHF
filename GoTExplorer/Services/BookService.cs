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
    class BookService
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

        public async Task<List<Book>> GetBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books"));
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await GetAsync<Book>(new Uri(serverUrl, $"api/books/{id}"));
        }

        public async Task<List<Book>> GetBookAsync(string name)
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, $"api/books?name=" + name.Replace(' ', '+')));
        }
    }
}
