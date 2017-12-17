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
	public partial class AvailMed : ContentPage
	{

        public class Bookapi
        {
            public string book_id { get; set; }
            public string book_title { get; set; }
            public string book_copies { get; set; }


        }

        public class RootObject
        {
            public List<Bookapi> bookapi { get; set; }
        }

        public AvailMed ()
		{
			InitializeComponent ();
            LoadData();
		}

        public async void LoadData()
        {
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync("http://gchits.esy.es/gchitsApi/medicineApi.php");
            var json = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<RootObject>(json);
            GCHITS.ItemsSource = jsonObject.bookapi;

        }
    }
}