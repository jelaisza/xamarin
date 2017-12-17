using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;

namespace GCHITS1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        public class Login{
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

        public override string ToString()
        {
            return string.Format("username: {0} password: {1} ", username, password);
        }
    }

        async void loginpage(object sender, EventArgs e)
        {

            try
            {
                string username1 = username.Text;
                string password1 = password.Text;

                String Url1 = "http://gchits.esy.es/gchitsApi/loginApi.php?username=" + username1 + "&password=" + password1;

                var client = new System.Net.Http.HttpClient();
                var response1 = await client.GetAsync(Url1);


                var json1 = await response1.Content.ReadAsStringAsync();
                var result1 = JsonConvert.DeserializeObject(json1);

                string newRes = result1.ToString().Replace("[", string.Empty).Replace("]", string.Empty);
                var newObj = JsonConvert.DeserializeObject<Login>(newRes);

                if (username1 == newObj.username && password1 == newObj.password)
                {
                    await DisplayAlert("", "Welcome to GCHITS  " + newObj.fullname, "OK");
                    await Navigation.PushModalAsync(new MainPage(newObj.username));
                }

                else
                {
                    await DisplayAlert("", "Email or Password is Incorrect", "OK");

                }
            }

            catch
            {

            }

        }

    }
}
