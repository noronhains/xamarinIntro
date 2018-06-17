using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.MasterDetail
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void BtnPag1_Clicked(object sender, EventArgs e)
        {
            Detail = new Navigation.Pagina1();
            IsPresented = false;
        }

        private void BtnPag2_Clicked(object sender, EventArgs e)
        {
            Detail = new Navigation.Pagina2();
            IsPresented = false;
        }

        private void BtnCont_Clicked(object sender, EventArgs e)
        {
            Detail = new Conteudo();
            IsPresented = false;
        }
    }
}