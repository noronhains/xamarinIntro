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
                Navigation.PushAsync(new Pages.Perfil1());
            }
            else if (((Button)sender).Text == "Sobre a Xamarin")
            {
                Navigation.PushAsync(new Pages.Xamarin());
            }           
                
        }
    }
}