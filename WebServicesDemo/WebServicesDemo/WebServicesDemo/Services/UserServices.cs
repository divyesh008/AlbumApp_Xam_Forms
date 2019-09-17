using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServicesDemo.Model;

namespace WebServicesDemo.Services
{
    public class UserServices
    {
        public async Task<List<User>> GetUsersAsync()
        {
            RestClient<User> restClient = new RestClient<User>();

            var usersList = await restClient.GetAsync();

            return usersList;   
        }

        public async Task<List<Album>> GetAlbumAsync()
        {
            RestClient<Album> restClient = new RestClient<Album>();

            var albumsList = await restClient.GetAlbums();

            return albumsList;
        }

    }
}
