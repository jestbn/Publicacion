using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TallerApis.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Publicacion : ContentPage
	{
		public Publicacion ()
		{
			InitializeComponent();
            CargarPublicacion();
		}

        private async Task CargarPublicacion()
        {
            HttpClient cliente = new HttpClient
            {
                BaseAddress = new Uri("https://apipublicacion.azurewebsites.net/")
            };
            var request = await cliente.GetAsync("Api/Publicacion");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<List<Publicacion>>(responseJson);
                ListPublicacion.ItemsSource = response;
            }
        }

        private void ListPublicacion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var producto = e.SelectedItem as Publicacion;
            DisplayAlert("Publicacion seleccionada: ", Convert.ToString(producto), "ok");
        }
    }
}