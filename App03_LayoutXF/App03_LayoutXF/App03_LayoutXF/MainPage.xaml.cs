using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App03_LayoutXF
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Stack")
            {
                Navigation.PushAsync(new Layouts.StackLayout.StackPage());
            }
            else if (((Button)sender).Text == "Relative")
            {
                Navigation.PushAsync(new Layouts.Relative.RelativePage());
            }
            else if (((Button)sender).Text == "Scroll")
            {
                Navigation.PushAsync(new Layouts.Scroll.ScrollPage());
            }
            else if (((Button)sender).Text == "Absolute")
            {
                Navigation.PushAsync(new Layouts.Absolute.AbsolutePage());
            }
            else if (((Button)sender).Text == "Grid")
            {
                Navigation.PushAsync(new Layouts.Grid.GridPage());
            }
        }
    }
}
