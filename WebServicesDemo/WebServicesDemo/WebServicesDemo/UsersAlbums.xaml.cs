using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServicesDemo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServicesDemo
{
    public partial class UsersAlbums : ContentPage
    {
        AlbumViewModel viewModel;
        public UsersAlbums()
        {
            InitializeComponent();
            BindingContext = viewModel = new AlbumViewModel();
        }
    }
}