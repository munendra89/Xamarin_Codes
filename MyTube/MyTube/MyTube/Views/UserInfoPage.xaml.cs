using MyTube.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTube.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfoPage : ContentPage
    {
        public UserInfoPage()
        {
            InitializeComponent();
            BindingContext = new UserInfoViewModel();
        }
    }
}