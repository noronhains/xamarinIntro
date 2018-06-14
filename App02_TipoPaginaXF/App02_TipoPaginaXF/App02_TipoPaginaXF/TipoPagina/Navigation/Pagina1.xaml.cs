using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pagina1 : ContentPage
	{
		public Pagina1 ()
		{
			InitializeComponent ();
		}

        private void BtnIr_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pagina2());
        }

        private void BtnModal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Modal());
        }

        private void BtnMaster_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MasterDetail.Master());
        }
    }
}