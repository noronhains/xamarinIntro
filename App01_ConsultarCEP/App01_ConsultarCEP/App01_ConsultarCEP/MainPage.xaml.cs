using System;
using System.Numerics;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {

            string cep = entCep.Text.Trim();

            try
            {
                if (cep.Contains("-")) { cep = cep.Remove(cep.IndexOf('-')); }

                bool isnumeric = true;
                char[] datachars = cep.ToCharArray();

                foreach (var datachar in datachars) {
                    if (char.IsDigit(datachar)) {

                        isnumeric = true;

                    }
                    else
                    {

                        isnumeric = false;

                    }
                    if (isnumeric == false)
                    {
                        throw new Exception("Digite apenas números!");
                    }

                }
                
                //if (!isnumeric) { throw new Exception("Digite apenas números!"); }
                if (cep.Length < 8) { throw new Exception("CEP muito pequeno!"); }
                if (cep.Length > 8) { throw new Exception("CEP muito grande!"); }
                if (cep.Contains(",") || cep.Contains(".")) { throw new Exception("Existem caracteres inválidos!\nDigite apenas números."); }
                          
                                
                Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);

                txtResultado.Text = string.Format("Endereço: {0} - {1}\nCidade: {2} - {3}", end.Logradouro, end.Bairro, end.Localidade, end.Uf);

            }
            catch(Exception ex)
            {
                DisplayAlert(ex.Message, "CEP inválido", "Ok");
                return;
            }
            
        }
    }
}
