using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGasolina.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Historico : ContentPage
	{
		public Historico ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var dados = new AcessoDB())
            {
                lstHistorico.ItemsSource = dados.GetAbastecimentos();
            }
        }

        private void LstHistorico_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            Navigation.PushModalAsync(new NavigationPage(new Detalhes(Convert.ToInt16(e.Item.ToString().Split('-')[0]))));

        }
    }
}