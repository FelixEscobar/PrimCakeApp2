using System.Threading.Tasks;
using PrimCakeApp2.Interfaces;
using PrimCakeApp2.Models;
using Xamarin.Essentials;


namespace PrimCakeApp2.Services
{
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;

        public UserService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<bool> Login(string email, string password)
        {
            var login = new
            {
                Email = email,
                Password = password
            };

            var result = await _apiService.PostAsync<Session>(login, "users/login");

            if (!result.IsSuccess)
            {
                return false;
            }

            Preferences.Set("accessToken", result.Result.AccessToken);
            return true;
        }

        public async Task<bool> Register(string name, string email, string password)
        {
            var register = new
            {
                Name = name,
                Email = email,
                Password = password
            };

            var result = await _apiService.PostAsync<string>(register, "users/signup");
            return result.IsSuccess;
        }
    }
}
