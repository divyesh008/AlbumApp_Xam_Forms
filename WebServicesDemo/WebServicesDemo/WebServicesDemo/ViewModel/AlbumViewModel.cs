using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebServicesDemo.Model;
using WebServicesDemo.Services;

namespace WebServicesDemo.ViewModel
{
    public class AlbumViewModel : INotifyPropertyChanged
    {
        private List<Album> _albumList;

        private List<Album> AlbumList
        {
            get { return _albumList; }

            set
            {
                _albumList = value;
                OnPropertyChanged();
            }
        }

        public AlbumViewModel()
        {
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var userService = new UserServices();

            AlbumList = await userService.GetAlbumAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
