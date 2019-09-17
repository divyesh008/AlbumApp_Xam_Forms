using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServicesDemo.Model;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {
        /// <summary>
        /// Users API Call 
        /// </summary>
        private const string WebServiceUrl = "http://jsonplaceholder.typicode.com/users";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var userModels = JsonConvert.DeserializeObject<List<T>>(json);

            return userModels;
        }

        /// <summary>
        /// Albums API Call
        /// </summary>
        private const string AlbumApi = "https://jsonplaceholder.typicode.com/albums";

        public async Task<List<T>> GetAlbums()
        {
            var httpClient = new HttpClient();

            var albumJson = await httpClient.GetStringAsync(AlbumApi);

            var albumModels = JsonConvert.DeserializeObject<List<T>>(albumJson);

            return albumModels;
        }


    }
}
