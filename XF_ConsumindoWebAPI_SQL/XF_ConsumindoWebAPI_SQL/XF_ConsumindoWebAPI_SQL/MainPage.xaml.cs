using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_ConsumindoWebAPI_SQL.Service;
using XF_ConsumindoWebAPI_SQL.Models;

namespace XF_ConsumindoWebAPI_SQL
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

            if (((ToolbarItem)sender).Text == toolRefresh.Text) {
                AtualizaDados();
            }
            else if (((ToolbarItem)sender).Text == toolClean.Text)
            {
                LimpaProduto();
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
                    produtoAtualizar.Descricao = txtDescricao.Text;
                    produtoAtualizar.Preco = Convert.ToDouble(txtPreco.Text);
                    produtoAtualizar.Estoque = Convert.ToInt32(txtEstoque.Text);

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
            txtDescricao.Text = produto.Descricao;
            txtPreco.Text = produto.Preco.ToString();
            txtEstoque.Text = produto.Estoque.ToString();
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
                    Descricao = txtDescricao.Text.Trim(),
                    Preco = Convert.ToDouble(txtPreco.Text),
                    Estoque = Convert.ToInt32(txtEstoque.Text)
                };
                try
                {
                    await dataService.AddProdutoAsync(novoProduto);
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
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtEstoque.Text))
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
            txtDescricao.Text = "";
            txtNome.Text = "";
            txtPreco.Text = "";
            txtEstoque.Text = "";
        }
    }
}
