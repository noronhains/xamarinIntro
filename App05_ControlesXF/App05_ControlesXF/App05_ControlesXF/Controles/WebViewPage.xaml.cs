using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControlesXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked_Ir(object sender, EventArgs e)
        {
            if (!txtUrl.Text.Contains("http://www."))
            { 
                txtUrl.Text = "http://www." + txtUrl.Text;
            }
            webV.Source = txtUrl.Text;
        }
        private void Button_Clicked_Voltar(object sender, EventArgs e)
        {
            if (webV.CanGoBack)
                webV.GoBack();
        }
        private void Button_Clicked_Prox(object sender, EventArgs e)
        {
            if (webV.CanGoForward)
                webV.GoForward();
        }

        private void webV_Navigated(object sender, WebNavigatedEventArgs e)
        {
            lblStatus.Text = "Carregado";
        }

        private void webV_Navigating(object sender, WebNavigatingEventArgs e)
        {
            lblStatus.Text = "Carregando...";
        }

        private void txtUrl_Completed(object sender, EventArgs e)
        {
            if (!txtUrl.Text.Contains("http://www."))
            {
                txtUrl.Text = "http://www." + txtUrl.Text;
            }
            webV.Source = txtUrl.Text;
        }
    }
}