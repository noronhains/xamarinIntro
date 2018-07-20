using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App07_Cells.Pagina;

namespace App07_Cells.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

            if (((Button)sender).Text == "TextCell")
            {
                Detail = new NavigationPage(new TextCellPage());
                IsPresented = false;
            }
            else if (((Button)sender).Text == "ImageCell")
            {
                Detail = new NavigationPage(new ImageCellPage());
                IsPresented = false;
            }
            else if (((Button)sender).Text == "SwitchCell")
            {
                Detail = new NavigationPage(new SwitchCellPage());
                IsPresented = false;
            }
            else if (((Button)sender).Text == "ViewCell")
            {
                Detail = new NavigationPage(new ViewCellPage());
                IsPresented = false;
            }
            else if (((Button)sender).Text == "ListView")
            {
                Detail = new NavigationPage(new ListViewPage());
                IsPresented = false;
            }
            else if (((Button)sender).Text == "ListViewButton")
            {
                Detail = new NavigationPage(new ListViewButtonPage());
                IsPresented = false;
            }
        }
    }
}