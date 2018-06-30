using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGasolina.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalhes : ContentPage
	{
        private int codAbastecimento;

		public Detalhes (int codigoAbastecimento)
		{
			InitializeComponent ();
            codAbastecimento = codigoAbastecimento;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var dados = new AcessoDB())
            {
                Abastecimento abastecimento = dados.GetAbastecimento(codAbastecimento);
                double kmL;
                lblData.Text = "Data do abastecimento: " + abastecimento.Data;
                lblLitro.Text = "Litros abastecidos: " + abastecimento.Litro.ToString();
                lblPosto.Text = "Posto: " + abastecimento.Posto;
                lblPreco.Text = "Preço da gasolina no dia: " + abastecimento.Preco.ToString();
                lblValor.Text = "Valor abastecido: " + abastecimento.Valor.ToString();
                lblQuilometragem.Text = "Quilometragem desde o abastecimento anterior: " + abastecimento.Quilometragem.ToString();

                kmL = abastecimento.Quilometragem / abastecimento.Litro;

                lblKmL.Text = "Você fez " + kmL.ToString() + "Km/l";

            }
        }

        async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void BtnDeletar_Clicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Deletar", "Deseja mesmo deletar esse abastecimento?", "Sim", "Não");

            if (resposta)
            {
                using(var dados = new AcessoDB())
                {
                    dados.DeletarAbastecimento(codAbastecimento);
                    await Navigation.PopModalAsync();
                }
            }
        }
    }
}