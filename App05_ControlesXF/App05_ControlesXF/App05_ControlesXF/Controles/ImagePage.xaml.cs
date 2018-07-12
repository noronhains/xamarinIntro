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
	public partial class ImagePage : ContentPage
	{
		public ImagePage ()
		{
			InitializeComponent ();

            Image imgURL = new Image();

            if (Device.RuntimePlatform == Device.UWP)
            {
                imgURL.Source = ImageSource.FromFile("Imagem/usb.jpg");
            }
            else
            {
                imgURL.Source = ImageSource.FromFile("usb.jpg");
            }

            Container.Children.Add(imgURL);
        }
	}
}