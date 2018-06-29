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
	public partial class ProgressBarPage : ContentPage
	{
		public ProgressBarPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            bar1.ProgressTo(1, 5000, Easing.Linear);
            bar2.ProgressTo(1, 5000, Easing.SinIn);
            bar3.ProgressTo(1, 5000, Easing.SpringIn);
        }
    }
}