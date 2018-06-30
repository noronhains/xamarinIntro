using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppGasolina.Models;

namespace AppGasolina.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoAbastecimento : ContentPage
	{
		public NovoAbastecimento ()
		{
			InitializeComponent ();
		}

        private void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            using (var dados = new AcessoDB()) {
                var abastecimento = new Abastecimento
                {
                    Id = dados.UltimoCodigo() + 1,
                    Data = this.dtAbastecimento.Date.ToString("dd/MM/yyyy"),
                    Preco = Convert.ToDouble(this.entryPreco.Text),
                    Valor = Convert.ToDouble(this.entryValor.Text),
                    Quilometragem = Convert.ToDouble(this.entryQuilometragem.Text),
                    Litro = Convert.ToDouble(this.entryLitros.Text),
                    Posto = this.entryPosto.Text,
                };

                dados.InserirAbastecimento(abastecimento);

                Navigation.PushModalAsync(new NavigationPage(new Detalhes(dados.UltimoCodigo())));
                
            }
            
        }
	}
}