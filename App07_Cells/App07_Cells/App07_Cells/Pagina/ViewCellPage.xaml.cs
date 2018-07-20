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
	public partial class ViewCellPage : ContentPage
	{
		public ViewCellPage ()
		{
			InitializeComponent ();

            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios.Add(new Funcionario() { Nome = "José", Cargo = "Presidente" });
            funcionarios.Add(new Funcionario() { Nome = "Maria", Cargo = "Gerente de Vendas" });
            funcionarios.Add(new Funcionario() { Nome = "Elaine", Cargo = "Gerente de Marketing" });
            funcionarios.Add(new Funcionario() { Nome = "Felipe", Cargo = "Entregador" });
            funcionarios.Add(new Funcionario() { Nome = "João", Cargo = "Vendedor" });

            listaFuncionario.ItemsSource = funcionarios;
        }
	}
}