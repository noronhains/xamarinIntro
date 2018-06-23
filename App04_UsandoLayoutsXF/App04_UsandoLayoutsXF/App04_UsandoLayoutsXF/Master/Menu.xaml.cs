using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App04_UsandoLayoutsXF.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(((Button)sender).Text == "Miguel de Icaza")
            {
                Detail = new NavigationPage(new Pages.Perfil1());
                this.IsPresented = false;
            }
            else if (((Button)sender).Text == "Sobre a Xamarin")
            {
                Detail = new NavigationPage(new Pages.Xamarin());
                this.IsPresented = false;
            }           
                
        }
    }
}