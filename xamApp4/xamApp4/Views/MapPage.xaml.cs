using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                         new Position(45.172285, -93.874306), Distance.FromMeters(50.00D)));

                //var zoomLevel = 18; // pick a value between 1 and 18
                //var latlongdeg = 360 / (Math.Pow(2, zoomLevel));
                //ShopsMap.MoveToRegion(new MapSpan(ShopsMap.VisibleRegion.Center, latlongdeg, latlongdeg));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}