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
    public partial class Detail
    {
        string user;
        public Detail(string username)
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
            public string req_status { get; set; }
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

            fullname.Text = newObj.fullname;
            req_status.Text = newObj.req_status;
            course.Text = newObj.course;
            age.Text = newObj.age;
            birthday.Text = newObj.birthday;
            status.Text = newObj.status;
            contact.Text = newObj.contact;
            history.Text = newObj.history;
            accident.Text = newObj.accident;
            accidentdate.Text = newObj.accidentdate;
            e_name.Text = newObj.e_name;


        }

        async void Info(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail.Navigation.PushAsync(new Detail(user) { Title = "My Records " });
        }

        async void Medical(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail.Navigation.PushAsync(new Medical(user) { Title = "Medical Records " });
        }


        async void Dental(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            App.MasterDetail.Detail.Navigation.PushAsync(new Dental(user) { Title = "Dental Records " });
        }

    }
}