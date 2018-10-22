using System;
using Food_Journal.DB.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Food_Journal.ClientApi.Controllers
{
    public interface IUserController
    {
        Task<User> LoginUser(string username, string hashedPassword);
        Task<bool> UsernameExists(string username);
        Task<User> CreateUser(User user);
        Task<User> ShowUser(int id);
        Task<User> UpdateUser(int id, User user);
    }

    public class UserController : BaseController<User>, IUserController
    {
        protected override string ControllerEndpoint => "users";

        public async Task<User> LoginUser(string username, string hashedPassword)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new
                    Uri(BASE_ADDRESS);

                var path = $"{BASE_ENDPOINT}/{ControllerEndpoint}/login";

                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(path),
                    Method = HttpMethod.Post,
                };

                request.Headers.Add("username", username);
                request.Headers.Add("password", hashedPassword);

                try
                {
                    var response = await client.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(json);
                    return user;
                }
                catch
                {
                    throw;
                    //return null;
                }
            }
        }

        public async Task<bool> UsernameExists(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new
                    Uri(BASE_ADDRESS);
                
                var path = $"{BASE_ENDPOINT}/{ControllerEndpoint}/check_username?username={username}";
                try
                {
                    var response = await client.GetStringAsync(path);
                    return bool.Parse(response);
                }
                catch
                {
                    throw;
                    //return false;
                }
            }
        }

        public Task<User> ShowUser(int id)
        {
            return _ShowAsync(id);
        }

        public Task<User> CreateUser(User user)
        {
            return _CreateAsync(user);
        }

        public Task<User> UpdateUser(int id, User user)
        {
            return _UpdateAsync(id, user);
        }
    }
}
