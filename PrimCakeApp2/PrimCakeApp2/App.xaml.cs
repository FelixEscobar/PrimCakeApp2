using PrimCakeApp2.Helpers;
using PrimCakeApp2.Interfaces;
using PrimCakeApp2.ViewModels;
using PrimCakeApp2.Views;
using PrimCakeApp2.PlatformSpecific;
using PrimCakeApp2.Services;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrimCakeApp2
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var accessToken = Preferences.Get("accessToken", string.Empty);

            if (string.IsNullOrEmpty(accessToken))
            {
                await NavigationService.NavigateAsync("NavigationPage/SignUpPage");
            }
            else
            {
                if (TokenValidator.CheckTokenValidity())
                {
                    await NavigationService.NavigateAsync("NavigationPage/HomePage");
                }
                else
                {
                    await NavigationService.NavigateAsync("NavigationPage/SignUpPage");
                }
            }
        }

        protected override void OnStart()
        {
            var setupTheme = DependencyService.Get<ISetupTheme>();
            setupTheme.SetStatusBarColor((Color)Current.Resources["StatusBar"]);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductListPage, ProductListPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();

            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IUserService, UserService>();
        }
    }
}
