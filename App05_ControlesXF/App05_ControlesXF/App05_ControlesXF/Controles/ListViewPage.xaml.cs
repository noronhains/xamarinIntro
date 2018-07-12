using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App05_ControlesXF.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControlesXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            List<Pessoa> pessoas = new List<Pessoa>();

            pessoas.Add(new Pessoa() { Nome = "Igor Noronha", Idade = 21 });
            pessoas.Add(new Pessoa() { Nome = "Ana Clara", Idade = 19 });
            pessoas.Add(new Pessoa() { Nome = "Teresa Cristina", Idade = 55 });
            pessoas.Add(new Pessoa() { Nome = "Hélio Heli", Idade = 64 });
            pessoas.Add(new Pessoa() { Nome = "Maria Apparecida", Idade = 87 });

            ListaPessoas.ItemsSource = pessoas;

        }
	}
}