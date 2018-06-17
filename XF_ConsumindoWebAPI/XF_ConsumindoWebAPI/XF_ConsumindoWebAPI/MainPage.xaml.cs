using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_ConsumindoWebAPI.Service;
using XF_ConsumindoWebAPI.Models;

namespace XF_ConsumindoWebAPI
{
	public partial class MainPage : ContentPage
	{

        DataService dataService;
        List<Produto> produtos;

		public MainPage()
		{
			InitializeComponent();
            dataService = new DataService();
            LimpaProduto();
            AtualizaDados();
		}

        async void AtualizaDados()
        {
            produtos = await dataService.GetProdutosAsync();
            listaProdutos.ItemsSource = produtos.OrderBy(item => item.Nome).ToList();
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

            if (((ToolbarItem)sender).Text == toolAdd.Text)
            {
                Navigation.PushAsync(new NewProdutoPage());
            }
            else if (((ToolbarItem)sender).Text == toolRefresh.Text) {
                AtualizaDados();
            }
            else if (((ToolbarItem)sender).Text == toolClean.Text)
            {
                LimpaProduto();
            }
            else
            {

            }

        }

        private async void OnAtualizar(object sender, EventArgs e)
        {
           if (Valida())
           {
               try
               {
                    var mi = ((MenuItem)sender);
                    Produto produtoAtualizar = (Produto)mi.CommandParameter;

                    produtoAtualizar.Nome = txtNome.Text;
                    produtoAtualizar.Categoria = txtCategoria.Text;
                    produtoAtualizar.Preco = Convert.ToDouble(txtPreco.Text);

                    await dataService.UpdateProdutoAsync(produtoAtualizar);

                    LimpaProduto();
                    AtualizaDados();
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

        private async void OnDeletar(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                Produto produtoDeletar = (Produto)mi.CommandParameter;
                await dataService.DeletaProdutoAsync(produtoDeletar);
                LimpaProduto();
                AtualizaDados();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void ListaProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var produto = e.SelectedItem as Produto;
            txtNome.Text = produto.Nome;
            txtCategoria.Text = produto.Categoria;
            txtPreco.Text = produto.Preco.ToString();
        }

        private void ContentPage_Focused(object sender, FocusEventArgs e)
        {
            AtualizaDados();
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
                    LimpaProduto();
                    AtualizaDados();
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

        private void LimpaProduto()
        {
            txtCategoria.Text = "";
            txtNome.Text = "";
            txtPreco.Text = "";
        }
    }
}
