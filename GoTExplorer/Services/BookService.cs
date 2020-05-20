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
    ///     Service responsible to get the data of books.
    /// </summary>
    class BookService
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
        ///     Method to get a list of books from the server. 10 books will be returned per call.
        /// </summary>
        /// <param name="pageNumber">page number for paging.</param>
        public async Task<List<Book>> GetBooksAsync(int pageNumber)
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books?page=" + pageNumber));
        }

        /// <summary>
        ///     Method to get a single book from the server. The book is identified by its ID.
        /// </summary>
        /// <param name="id">id of the target book.</param>
        public async Task<Book> GetBookAsync(int id)
        {
            return await GetAsync<Book>(new Uri(serverUrl, $"api/books/{id}"));
        }

        /// <summary>
        ///     Method to get a single book from the server. The book is identified by its name.
        /// </summary>
        /// <param name="name">name of the target book.</param>
        public async Task<List<Book>> GetBookAsync(string name)
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, $"api/books?name=" + name.Replace(' ', '+')));
        }
    }
}
