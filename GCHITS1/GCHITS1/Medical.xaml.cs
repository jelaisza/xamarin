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
    public partial class Medical

    {
        string user;
        public Medical(string username)
        {
            user = username;
            InitializeComponent();
            loadData();
        }

        public class Login
        {
            public string id { get; set; }
            public string username { get; set; }
            public string password { get; set; }

            public string fullname { get; set; }
            public string course { get; set; }
            public string age { get; set; }
            public string birthday { get; set; }
            public string status { get; set; }
            public string address { get; set; }
            public string contact { get; set; }
            public string history { get; set; }
            public string accident { get; set; }
            public string accidentdate { get; set; }
            public string e_name { get; set; }

            public string pe_bp { get; set; }
            public string pe_bmi { get; set; }
            public string pe_chest { get; set; }
            public string pe_cr { get; set; }
            public string pe_temp { get; set; }
            public string pe_heart { get; set; }
            public string pe_rr { get; set; }
            public string pe_activity { get; set; }
            public string pe_abdomen { get; set; }
            public string pe_weight { get; set; }
            public string pe_height { get; set; }

            public string pe_skin { get; set; }
            public string pe_extremities { get; set; }

            public string pe_heent { get; set; }


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

            pe_bp.Text = newObj.pe_bp;
            pe_bmi.Text = newObj.pe_bmi;
            pe_chest.Text = newObj.pe_chest;
            pe_cr.Text = newObj.pe_cr;

            pe_temp.Text = newObj.pe_temp;
            pe_heart.Text = newObj.pe_heart;
            pe_rr.Text = newObj.pe_rr;
            pe_activity.Text = newObj.pe_activity;

            pe_abdomen.Text = newObj.pe_abdomen;
            pe_weight.Text = newObj.pe_weight;
            pe_height.Text = newObj.pe_height;
            pe_skin.Text = newObj.pe_skin;

            pe_extremities.Text = newObj.pe_extremities;
            pe_heent.Text = newObj.pe_heent;

        }


        async void Info(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail.Navigation.PushAsync(new Detail(user) { Title = "My Records " });
        }


        async void Dental(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail.Navigation.PushAsync(new Dental(user) { Title = "Dental Records " });
        }





    }
}