using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using WebServicesDemo.Model;
using WebServicesDemo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace WebServicesDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        MainViewModel viewModel;
        Map map;
        public UserDetailsPage()
        {
            InitializeComponent();
        }

        public UserDetailsPage(MainViewModel viewModel)
        {
            try
            {
                BindingContext = this.viewModel = viewModel;
                InitializeComponent();

                //RequestLocationPermission();
                map = new Map
                {
                    IsShowingUser = true,
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                SetMap(viewModel.Items.address.geo.lat, viewModel.Items.address.geo.lng);
                LocationMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(viewModel.Items.address.geo.lat, viewModel.Items.address.geo.lng), Distance.FromMiles(1)));
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void RequestLocationPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    //Permission granted, do what you want do.
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                //...
            }
        }

        private void SetMap(double lat, double lng)
        {
            LocationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lng), Distance.FromMiles(0.5)));

            //Pin
            var myPin = new Pin
            {
                Type = PinType.Generic,
                Position = new Position(lat, lng),
                Label = viewModel.Items.name,
                Address = "City: " + viewModel.Items.address.city + ", Street: " + viewModel.Items.address.street
            };
            LocationMap.Pins.Add(myPin);

        }

        async void ToolbarItem_Clicked(object sender, EventTrigger e)
        {
            await Navigation.PushAsync(new UsersAlbums());
        }
    }
}