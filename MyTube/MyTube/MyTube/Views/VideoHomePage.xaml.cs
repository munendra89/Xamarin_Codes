using MyTube.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTube.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoHomePage : ContentPage
    {
        public VideoHomePage()
        {
            InitializeComponent();
            BindingContext = new VideoHomePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();          
        }
    }
}