using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App06_Tarefas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
		public Cadastro ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var Stacks = SLPrioridades.Children;

            foreach(var stack in Stacks)
            {
                Label LblPrioridade = ((StackLayout)stack).Children[1] as Label;
                LblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            string prioridade = source.File.ToString().Replace("Resources/", "").Replace(".png", "").Replace("p", "");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}