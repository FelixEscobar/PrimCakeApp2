using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.CurrentActivity;
using PrimCakeApp2.PlatformSpecific;


[assembly: Dependency(typeof(PrimCakeApp2.Droid.PlatformSpecific.SetupTheme))]
namespace PrimCakeApp2.Droid.PlatformSpecific
{
    public class SetupTheme: ISetupTheme
    {
        public void SetStatusBarColor(Color color)
        {
            var androidColor = color.ToAndroid();

            CrossCurrentActivity.Current.Activity.Window.SetStatusBarColor(androidColor);
        }
    }
}