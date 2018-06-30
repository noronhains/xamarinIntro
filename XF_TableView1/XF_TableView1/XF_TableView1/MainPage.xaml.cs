using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_TableView1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void AlertaCinto_Changed(object sender, ToggledEventArgs e)
        {
            if (this.AlertaCinto.On)
            {
                DisplayAlert("Alerta Cinto Segurança", "Você selecionou este acessório.", "Ok");
            }
            else
            {
                DisplayAlert("Alerta Cinto Segurança", "Você deselecionou este acessório.", "Ok");
            }
        }
	}
}
