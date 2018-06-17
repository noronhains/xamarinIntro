using System;
using XF_ConsumindoWebAPI.Models;
using XF_ConsumindoWebAPI.Service;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_ConsumindoWebAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewProdutoPage : ContentPage
	{

        DataService dataService;
 
        public NewProdutoPage ()
		{
			InitializeComponent ();
            dataService = new DataService();
        }

        private async void BtnAdicionar_Clicked(object sender, EventArgs e)
        {
            if (Valida())
            {
                Produto novoProduto = new Produto
                {
                    Nome = txtNome.Text.Trim(),
                    Categoria = txtCategoria.Text.Trim(),
                    Preco = Convert.ToDouble(txtPreco.Text)
                };
                try
                {
                    await dataService.AddProdutoAsync(novoProduto);
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Dados inválidos", "OK");
            }
        }
        
        private bool Valida()
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtNome.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}