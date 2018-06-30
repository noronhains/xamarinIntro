using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.TextToSpeech;

namespace AppParlaXF
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void BtnParla_Clicked(object sender, EventArgs args)
        {
            var texto = txtTexto.Text;
            CrossTextToSpeech.Current.Speak(texto);
        }

    }
}
