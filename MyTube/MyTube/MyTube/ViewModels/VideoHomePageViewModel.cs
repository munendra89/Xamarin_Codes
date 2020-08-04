using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using MyTube.AppConstants;
using MyTube.DataModel;
using MyTube.Services;
using MyTube.Views;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTube.ViewModels
{
    public class VideoHomePageViewModel: BaseViewModel
    {
        
        public VideoHomePageViewModel()
        {
            GetVideos();
        }

        public async void GetVideos()
        {
            IsBusy = true;
            VideoListResponse videoListResponse = await YouTubeServiceClient.Instance.GetVideoList();
            var videoItemList = GetVideoItemsList(videoListResponse);
            VideoItems = videoItemList;
            IsBusy = false;
        }

        private static List<VideoItem> GetVideoItemsList(VideoListResponse videoListResponse)
        {
            var videoItemList = new List<VideoItem>();
            foreach (var item in videoListResponse.Items)
            {
                var snippet = item.Snippet;
                var statistics = item.Statistics;

                var vdItem = new VideoItem
                {
                    Title = snippet.Title,
                    Description = snippet.Description,
                    ChannelTitle = snippet.ChannelTitle,
                    PublishedAt = snippet.PublishedAt,
                    VideoId = item?.Id,
                    DefaultThumbnailUrl = snippet?.Thumbnails?.Default__?.Url,
                    MediumThumbnailUrl = snippet?.Thumbnails?.Medium?.Url,
                    HighThumbnailUrl = snippet?.Thumbnails?.High?.Url,
                    StandardThumbnailUrl = snippet?.Thumbnails?.Standard?.Url,
                    MaxResThumbnailUrl = snippet?.Thumbnails?.Maxres?.Url,
                    MaxResThumbnailHeight = snippet?.Thumbnails?.Maxres?.Height,

                    ViewCount = (int?)(statistics?.ViewCount),
                    LikeCount = (int?)(statistics?.LikeCount),
                    DislikeCount = (int?)statistics?.DislikeCount,
                    FavoriteCount = (int?)statistics?.FavoriteCount,
                    CommentCount = (int?)statistics?.CommentCount,
                    Player = item.Player
                };

                videoItemList.Add(vdItem);
            }

            return videoItemList;
        }

        public Command VideoTapped => new Command<VideoItem>(Video_Tapped);

        public Command AccountTapped => new Command(Account_Tapped);

        private void Video_Tapped(VideoItem tappedItem)
        {
            Debug.WriteLine("ItemTapped" + tappedItem);
            Application.Current.MainPage.Navigation.PushAsync(new VideoPlayerPage(tappedItem,VideoItems));

        }

        private void Account_Tapped()
        {
            
            Application.Current.MainPage.Navigation.PushModalAsync(new UserInfoPage());
        }
      
    }
}
