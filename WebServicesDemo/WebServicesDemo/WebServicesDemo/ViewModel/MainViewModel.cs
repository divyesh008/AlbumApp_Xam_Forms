using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebServicesDemo.Model;
using WebServicesDemo.Services;
using Xamarin.Forms;

namespace WebServicesDemo.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<User> _usersList;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            //Users API
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var userServices = new UserServices();

            UsersList = await userServices.GetUsersAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<User> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }

        public User Items { get; set; }

        public MainViewModel(User item = null)
        {
            Items = item;
        }

        
    }
}
