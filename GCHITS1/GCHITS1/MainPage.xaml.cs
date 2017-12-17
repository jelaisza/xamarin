using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace GCHITS1
{
    public partial class MainPage : MasterDetailPage
    {

        string user;
        public MainPage(string username)
        {
            user = username;
            this.Master = new Master(user);
            this.Detail = new NavigationPage(new Detail(user));
            App.MasterDetail = this;
        }



    }
}
