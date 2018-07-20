using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App07_Cells.Modelo;

namespace App07_Cells.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalhe : ContentPage
	{
		public Detalhe (Funcionario funcionario)
		{
			InitializeComponent ();

            lblNome.Text = funcionario.Nome;
            lblCargo.Text = funcionario.Cargo;
            imgFunc.Source = funcionario.Foto;
		}
	}
}