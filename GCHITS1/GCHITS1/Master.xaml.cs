using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GCHITS1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        string user;
        public Master(string username)
        {
            user = username;
            InitializeComponent();

            Detail.Clicked += async (sender, e) =>
            {
                App.MasterDetail.IsPresented = false;
                await App.MasterDetail.Detail.Navigation.PushAsync(new Detail(user) { Title = "Home " });

            };


            Announcement.Clicked += async (sender, e) =>
            {
                App.MasterDetail.IsPresented = false;
                await App.MasterDetail.Detail.Navigation.PushAsync(new Announcement() { Title = "Announcement " });

            };



            AvailMed.Clicked += async (sender, e) =>
            {
                App.MasterDetail.IsPresented = false;
                await App.MasterDetail.Detail.Navigation.PushAsync(new AvailMed() { Title = "Available Medicine " });

            };





        }
    }
}