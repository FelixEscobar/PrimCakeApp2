using Acr.UserDialogs;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PrimCakeApp2.Interfaces;
using PrimCakeApp2.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrimCakeApp2.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response<T>> PostAsync<T>(object model, string service)
            where T : class
        {
            var current = Connectivity.NetworkAccess;
            var data = JsonConvert.SerializeObject(model);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var client = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.ApiUrl)
            };

            if (authRequired)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            }

            var response = await client.PostAsync($"{AppSettings.ApiUrl}/{service}", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResponse);

            return new Response<T>
            {
                IsSuccess = response.IsSuccessStatusCode,
                Result = result
            };
        }

        public async Task<Response<T>> GetAsync<T>(string service)
            where T : class
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.ApiUrl)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));

            var response = await client.GetAsync($"{AppSettings.ApiUrl}/{service}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResponse);

            return new Response<T>
            {
                IsSuccess = response.IsSuccessStatusCode,
                Result = result
            };
        }
    }
}
