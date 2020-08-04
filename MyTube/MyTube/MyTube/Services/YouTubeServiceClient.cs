using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using MyTube.AppConstants;
using MyTube.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyTube.Services
{
    public class YouTubeServiceClient
    {
        private static YouTubeServiceClient instance;

        public static YouTubeServiceClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new YouTubeServiceClient();
                }
                return instance;
            }
        }

        public async Task<VideoListResponse> GetVideoList()
        {
            string tokenString = await SecureStorage.GetAsync("Token");
            string accessToken = JsonConvert.DeserializeObject<TokenModel>(tokenString).AccessToken;
            var youTubeServcie = new YouTubeService(new BaseClientService.Initializer());
            string[] parts = new string[] { YoutubeApiConstants.PART_SNIPPT, YoutubeApiConstants.PART_PLAYER, YoutubeApiConstants.PART_STATISTICS };
            var videoListRequest = youTubeServcie.Videos.List(parts);
            videoListRequest.AccessToken = accessToken;
            videoListRequest.MaxResults = 20;
            videoListRequest.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
            return await videoListRequest.ExecuteAsync();
        }
    }
}
