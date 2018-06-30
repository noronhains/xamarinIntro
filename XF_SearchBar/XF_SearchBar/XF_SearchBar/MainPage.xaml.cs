using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_SearchBar
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        List<string> estados = new List<string>
        {
            "Acre",
            "Alagoas",
            "Amapá",
            "Amazonas",
            "Bahia",
            "Ceará",
            "Distrito Federal",
            "Espírito Santo",
            "Goiás",
            "Maranhão",
            "Mato Grosso",
            "Mato Grosso do Sul",
            "Minas Gerais",
            "Pará",
            "Paraíba",
            "Paraná",
            "Pernambuco",
            "Piauí",
            "Rio de Janeiro",
            "Rio Grande do Norte",
            "Rio Grande do Sul",
            "Rondônia",
            "Roraima",
            "Santa Catarina",
            "São Paulo",
            "Sergipe",
            "Tocantins"
        };

        private void SearchConteudo_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchConteudo.Text;
            if(keyword.Length >= 1)
            {
                var sugestao = estados.Where(c => c.ToLower().Contains(keyword.ToLower()));
                listaEstados.ItemsSource = sugestao;
                listaEstados.IsVisible = true;
            }
            else
            {
                listaEstados.IsVisible = false;
            }
        }

        private void ListaEstados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item as string == null)
            {
                return;
            }
            else
            {
                listaEstados.ItemsSource = estados.Where(c => c.Equals(e.Item as string));
                listaEstados.IsVisible = true;
                SearchConteudo.Text = e.Item as string;
            }
        }
	}
}
