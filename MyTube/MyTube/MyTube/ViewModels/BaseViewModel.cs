using MyTube.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyTube.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged ;
        // here's your shared IsBusy property
        private bool _isBusy;
        private List<VideoItem> _videoItems;
        private VideoItem _videoItemTapped;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                // again, this is very important
                OnPropertyChanged("IsBusy");
            }
        }

        public VideoItem VideoItemTapped
        {
            get { return _videoItemTapped; }
            set
            {
                _videoItemTapped = value;
                OnPropertyChanged("VideoItemTapped");
            }
        }

        public List<VideoItem> VideoItems
        {
            get { return _videoItems; }
            set
            {
                _videoItems = value;
                OnPropertyChanged("VideoItems");
            }
        }

        // this little bit is how we trigger the PropertyChanged notifier.

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
