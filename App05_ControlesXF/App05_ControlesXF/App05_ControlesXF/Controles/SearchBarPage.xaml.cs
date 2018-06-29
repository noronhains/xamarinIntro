using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControlesXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchBarPage : ContentPage
	{
        private List<String> empresasTI;

        public SearchBarPage ()
		{
			InitializeComponent ();

            empresasTI = new List<string>();

            empresasTI.Add("Google");
            empresasTI.Add("Microsoft");
            empresasTI.Add("Apple");
            empresasTI.Add("Uber");
            empresasTI.Add("IBM");
            empresasTI.Add("Tesla");

            
		}

        private void Preencher(List<String> empresasTI)
        {
            SearchResult.Children.Clear();

            foreach (var empresa in empresasTI)
            {
                SearchResult.Children.Add(new Label { Text = empresa });
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var resultado = empresasTI.Where(emp => emp.Contains(e.NewTextValue)).ToList<String>();
            Preencher(resultado);
        }
    }
}