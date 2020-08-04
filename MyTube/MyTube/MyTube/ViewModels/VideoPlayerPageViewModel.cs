using Google.Apis.YouTube.v3.Data;
using MyTube.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyTube.ViewModels
{
    class VideoPlayerPageViewModel : BaseViewModel
    {
        private HtmlWebViewSource _source;

        public HtmlWebViewSource HtmlSource { 
            get => _source;
            set
            {
                _source = value;
                OnPropertyChanged("HtmlSource");
            }
        }

        public VideoPlayerPageViewModel(VideoItem tappedItem, List<VideoItem> videos)
        {
            IsBusy = true;
            VideoItemTapped = tappedItem;
            VideoItems = videos;
            GetHtmlSource(VideoItemTapped);
            IsBusy = false;
        }

        public Command VideoTapped => new Command<VideoItem>(Video_Tapped);

        private void Video_Tapped(VideoItem tappedItem)
        {
            GetHtmlSource(tappedItem);
        }

        private void GetHtmlSource(VideoItem tappedItem)
        {
            StringBuilder strBuilder = new StringBuilder("src=");
            strBuilder.Append('"');
            string embedHtml = tappedItem.Player.EmbedHtml.Replace(strBuilder.ToString(), strBuilder.Append("https:").ToString());
            var htmlSource = new HtmlWebViewSource
            {
                Html = @"<html><body>" + embedHtml + "</body></html>"
            };
            HtmlSource = htmlSource;
        }

        public Command PageClose => new Command(PageClosing);


        private void PageClosing()
        {
            Application.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}
