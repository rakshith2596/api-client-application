using Library.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Api.Client
{
    public class LibraryApiClient
    {
        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            HttpResponseMessage response =  UrlConfig.WebApiClient.GetAsync("Book").Result;
            return await response.Content.ReadAsAsync<Task<IEnumerable<BookModel>>>().Result;
        }

        public async Task<IEnumerable<BookModel>> GetBookDetailsByID(int id)
        {
            HttpResponseMessage response = UrlConfig.WebApiClient.GetAsync("Book/" + id.ToString()).Result;
            return await response.Content.ReadAsAsync<Task<IEnumerable<BookModel>>>().Result;
        }

        public async Task<IEnumerable<BookModel>> AddBookData(BookModel book)
        {
            HttpResponseMessage response = UrlConfig.WebApiClient.PostAsJsonAsync("Book", book).Result;
            return await response.Content.ReadAsAsync<Task<IEnumerable<BookModel>>>().Result;
        }
    }
}
