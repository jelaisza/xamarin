using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
namespace GCHITS1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Announcement : ContentPage
	{

        public class Announcementapi
        {
            public string a_id { get; set; }
            public string a_subject { get; set; }
            public string a_content { get; set; }
            public string userPic { get; set; }
            public string a_by { get; set; }
        }

        public class RootObject
        {
            public List<Announcementapi> announcementapi { get; set; }
        }



        public Announcement()
        {

            InitializeComponent();
           LoadData();
        }

        public async void LoadData()
        {
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync("http://gchits.esy.es/gchitsApi/announcementApi.php");
            var json = await response.Content.ReadAsStringAsync();
            json = json.ToString().Replace("userPic\":\"", "userPic\":\"http://192.168.43.53/landing1/template/user_images/");
            var jsonObject = JsonConvert.DeserializeObject<RootObject>(json);
            GCHITS.ItemsSource = jsonObject.announcementapi;

        }




    }
}