using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using PrimCakeApp2.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrimCakeApp2.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Private Attributes
        private readonly IUserService _userService;
        private string _email;
        private string _password;
        #endregion

        #region Constructor
        public LoginPageViewModel(INavigationService navigation,
            IUserService userService)
            : base(navigation)
        {
            _userService = userService;

            SubmitCommad = new DelegateCommand(async () => await Login());
            GoBackCommand = new DelegateCommand(async () => await GoBack());
        }
        #endregion

        #region Public Properties
        public DelegateCommand SubmitCommad { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion

        #region Methods
        private async Task Login()
        {
            var current = Connectivity.NetworkAccess;
            UserDialogs.Instance.ShowLoading("Logging in...");

            var result = await _userService.Login(Email, Password);

            UserDialogs.Instance.HideLoading();

            if (current != NetworkAccess.Internet)
            {
                await UserDialogs.Instance.AlertAsync("No Internet Connection", "Error");
            }

                if (!result)
            {
                await UserDialogs.Instance.AlertAsync("Something went wrong", "Error");
            }
            else
            {
                await NavigationService.NavigateAsync("HomePage");
            }
        }

        private async Task GoBack()
        {
            await NavigationService.GoBackAsync(useModalNavigation: true);
        }
        #endregion
    }
}
