using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServicesDemo.Model;
using WebServicesDemo.ViewModel;
using Xamarin.Forms;

namespace WebServicesDemo
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new MainViewModel();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as User;
            if (item == null)
                return;

            await Navigation.PushAsync(new UserDetailsPage(new MainViewModel(item)));
            
            //Manually deselect item
            UsersListView.SelectedItem = null;
        }

      
    }
}
