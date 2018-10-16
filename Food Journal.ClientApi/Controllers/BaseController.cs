using Food_Journal.DB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Food_Journal.ClientApi.Controllers
{
    public abstract class BaseController<T> where T : BaseModel
    {
        const string BASE_ENDPOINT = "https://api-foodjournal.azurewebsites.net/api";

        /// <summary>
        /// The endpoint of the controller (without the slashes). ex: users
        /// </summary>
        protected virtual string ControllerEndpoint { get; }

        protected Task<List<T>> _ListAsync()
        {
            return _RequestApi<List<T>>("/");
        }

        protected Task<T> _ShowAsync(int id)
        {
            return _RequestApi<T>($"/{id}");
        }

        public async Task<T> _CreateAsync(T item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new
                    Uri("https://api-foodjournal.azurewebsites.net");

                var path = $"{BASE_ENDPOINT}/{ControllerEndpoint}/";
                var apiResult = await client.PostAsJsonAsync<T>(path, item);
                var json = await apiResult.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<T> _UpdateAsync(int id, T item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new
                    Uri("https://api-foodjournal.azurewebsites.net");

                var path = $"{BASE_ENDPOINT}/{ControllerEndpoint}/{id}";
                var apiResult = await client.PutAsJsonAsync<T>(path, item);
                var json = await apiResult.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<bool> _DeleteAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new
                    Uri("https://api-foodjournal.azurewebsites.net");

                var path = $"{BASE_ENDPOINT}/{ControllerEndpoint}/{id}";
                var apiResult = await client.DeleteAsync(path);
                
                return apiResult.IsSuccessStatusCode;
            }
        }

        protected async Task<TOut> _RequestApi<TOut>(string relativeEndpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new
                    Uri("https://api-foodjournal.azurewebsites.net");

                var path = $"{BASE_ENDPOINT}/{ControllerEndpoint}/{relativeEndpoint}";
                var json = await client.GetStringAsync(path);
                var result = JsonConvert.DeserializeObject<TOut>(json);
                return result;
            }
        }
    }
}
