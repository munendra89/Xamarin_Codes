using MyTube.DataModel;
using MyTube.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTube.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPlayerPage : ContentPage
    {
        public VideoPlayerPage(VideoItem tappedItem, List<VideoItem> videoItems)
        {
            InitializeComponent();
            BindingContext = new VideoPlayerPageViewModel(tappedItem,videoItems);
        }
    }
}