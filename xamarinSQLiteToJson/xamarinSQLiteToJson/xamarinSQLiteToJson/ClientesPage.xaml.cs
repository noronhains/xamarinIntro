using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinSQLiteToJson
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientesPage : ContentPage
	{
		public ClientesPage ()
		{
			InitializeComponent ();

            using (var dados = new AcessoBD())
            {
                this.ListaCliente.ItemsSource = dados.GetClientes();
            }
        }

        protected void SalvarClick(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                Nome = this.NomeCliente.Text,
                Email = this.EmailCliente.Text,
            };
            using(var dados = new AcessoBD())
            {
                dados.InserirCliente(cliente);
                this.ListaCliente.ItemsSource = dados.GetClientes();
            }
        }

        private void Exportar_Clicked(object sender, EventArgs e)
        {
            using (var dados = new AcessoBD())
            {
                dados.ExportaJson();                
            }
        }
    }
}