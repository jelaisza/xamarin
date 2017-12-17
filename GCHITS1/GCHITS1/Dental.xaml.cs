using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GCHITS1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dental : ContentPage
	{
        string user;
        public Dental (string username)
		{
            user = username;
            InitializeComponent ();
            loadData();
        }

        public class Login
        {
            public string id { get; set; }
            public string username { get; set; }
            public string password { get; set; }


            public string d_tongue { get; set; }
            public string d_cheeks { get; set; }
            public string d_kidney{ get; set; }
            public string d_palate { get; set; }
            public string d_allergies { get; set; }
            public string d_liver { get; set; }
            public string d_tonsils { get; set; }
            public string d_heartdisease { get; set; }
            public string d_others { get; set; }
            public string d_lips { get; set; }
            public string d_blood { get; set; }
            public string d_hygiene { get; set; }
            public string d_floor { get; set; }
            public string d_diabetes { get; set; }
            public string upper_left { get; set; }
            public string upper_right { get; set; }
            public string lower_left { get; set; }
            public string lower_right { get; set; }

            public override string ToString()
            {
                return string.Format("username: {0} password: {1} ", username, password);
            }
        }


        async void loadData()
        {
            String Url1 = "http://gchits.esy.es/gchitsApi/recordApi.php?username=" + user;

            var client = new System.Net.Http.HttpClient();
            var response1 = await client.GetAsync(Url1);


            var json1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject(json1);

            string newRes = result1.ToString().Replace("[", string.Empty).Replace("]", string.Empty);
            var newObj = JsonConvert.DeserializeObject<Login>(newRes);

            d_tongue.Text = newObj.d_tongue;
            d_cheeks.Text = newObj.d_cheeks;
            d_kidney.Text = newObj.d_kidney;
            d_palate.Text = newObj.d_palate;

            d_allergies.Text = newObj.d_allergies;
            d_liver.Text = newObj.d_liver;
            d_tonsils.Text = newObj.d_tonsils;
            d_heartdisease.Text = newObj.d_heartdisease;

            d_others.Text = newObj.d_others;
            d_lips.Text = newObj.d_lips;
            d_blood.Text = newObj.d_blood;
            d_hygiene.Text = newObj.d_hygiene;

            d_floor.Text = newObj.d_floor;
            d_diabetes.Text = newObj.d_diabetes;

            upper_left.Text = newObj.upper_left;
            upper_right.Text = newObj.upper_right;
            lower_left.Text = newObj.lower_left;
            lower_right.Text = newObj.lower_right;



        }

        async void Info(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail.Navigation.PushAsync(new Detail(user) { Title = "My Records " });
        }

        async void Medical(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail.Navigation.PushAsync(new Medical(user) { Title = "Medical Records" });
        }



    }
}