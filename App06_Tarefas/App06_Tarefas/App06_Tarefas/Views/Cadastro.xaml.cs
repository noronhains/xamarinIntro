using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App06_Tarefas.Models;
using App06_Tarefas.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App06_Tarefas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
        private byte Prioridade { get; set; }
		public Cadastro ()
		{
			InitializeComponent ();
            Prioridade = 0;
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
            Prioridade = byte.Parse(prioridade);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (TxtNome.Text == null || TxtNome.Text.Trim().Length == 0)
                {
                    DisplayAlert("Nome inválido", "Dê um nome à sua tarefa antes de salvá-la.", "Ok");
                    return;
                }
                if (this.Prioridade == 0)
                {
                    DisplayAlert("Prioridade inválida", "Escolha a prioridade antes de salvar sua tarefa.", "Ok");
                    return;
                }

                Tarefa tarefa = new Tarefa() { Nome = TxtNome.Text, Prioridade = this.Prioridade };

                GerenciadorTarefa gerenciadorTarefa = new GerenciadorTarefa();

                gerenciadorTarefa.Salvar(tarefa);

                App.Current.MainPage = new NavigationPage(new Inicio());

            }catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}