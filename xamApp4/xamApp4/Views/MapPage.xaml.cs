using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamApp4.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace xamApp4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
			BindingContext = new PinItemViewModel();

		}

        protected override async void OnAppearing()
        {
            try
            {
                Permission[] perms;
                perms = new Permission[1];
                perms[0] = Permission.Location;

                //var status2 = await CrossPermissions.Current.RequestPermissionsAsync(perms);


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
                    ShopsMap.IsShowingUser = true;
                    //Permission granted, do what you want do.
                }
                else //if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }

				

                ShopsMap.MoveToRegion(
                     MapSpan.FromCenterAndRadius(
                         new Position(45.172285, -93.874306), Distance.FromMeters(550.00D)));
				//ShopsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(39.8283459, -98.5794797), Distance.FromMiles(1500)));

				//var zoomLevel = 18; // pick a value between 1 and 18
				//var latlongdeg = 360 / (Math.Pow(2, zoomLevel));
				//ShopsMap.MoveToRegion(new MapSpan(ShopsMap.VisibleRegion.Center, latlongdeg, latlongdeg));
			}
			catch (Exception ex)
            {
                throw;
            }
        }

		private async void Pin_Clicked(object sender, EventArgs e)
		{
			Geocoder geoCoder = new Geocoder();
			Location location = null;

			// find the user's position
			try
			{
				// TODO: add cancellation token so we can timeout gracefully
				location = await Geolocation.GetLastKnownLocationAsync();

				if (location != null)
				{
					Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
				}
			}
			catch (FeatureNotSupportedException fnsEx)
			{
				// Handle not supported on device exception
			}
			catch (FeatureNotEnabledException fneEx)
			{
				// Handle not enabled on device exception
			}
			catch (PermissionException pEx)
			{
				// Handle permission exception
			}
			catch (Exception ex)
			{
				// Unable to get location
			}


			// find the position of the pin they clicked
			Pin clickedPin = sender as Pin;
			if (clickedPin == null)
				throw new Exception("Pin not found");



			// compute the distance between, no routing/pathing yet
			double distanceFromUser = Location.CalculateDistance(location.Latitude, location.Longitude, clickedPin.Position.Latitude, clickedPin.Position.Longitude, DistanceUnits.Miles);
			distanceFromUser = distanceFromUser * 5280.00;

			await DisplayAlert("click", "distance: "+distanceFromUser.ToString() + " feet", "done");
		}
	}
}