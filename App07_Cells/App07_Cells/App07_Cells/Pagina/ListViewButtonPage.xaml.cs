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
	public partial class ListViewButtonPage : ContentPage
	{
		public ListViewButtonPage ()
		{
			InitializeComponent ();

            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios.Add(new Funcionario() { Foto = "http://www.paulorobertoelias.com/img/profile.png", Nome = "José", Cargo = "Presidente" });
            funcionarios.Add(new Funcionario() { Foto = "http://richtergruppe.com.br/wp-content/uploads/JosiRichter.png", Nome = "Maria", Cargo = "Gerente de Vendas" });
            funcionarios.Add(new Funcionario() { Foto = "http://thebook.is/files/clip/nilce-moretto-3723.jpg", Nome = "Elaine", Cargo = "Gerente de Marketing" });
            funcionarios.Add(new Funcionario() { Foto = "https://secure.gravatar.com/avatar/dd93950361725a36dd101543d0ed5c18?s=96&d=mm&r=g", Nome = "Felipe", Cargo = "Entregador" });
            funcionarios.Add(new Funcionario() { Foto = "http://1.gravatar.com/avatar/131ea35cab81aa12674b2b3358734e21?s=128&d=https%3A%2F%2Fwww.midiatismo.com.br%2Fwp-content%2Fthemes%2FMidiatismo%2Fimgs%2Fmystery-logo-150.jpg&r=g", Nome = "João", Cargo = "Vendedor" });

            listaFuncionario.ItemsSource = funcionarios;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            Funcionario func = (Funcionario)botao.CommandParameter;

            DisplayAlert(func.Nome, func.Nome + " (" + func.Cargo + ") está de férias", "Ok");
        }
    }
}