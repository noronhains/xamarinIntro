﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App06_Tarefas.Models;
using App06_Tarefas.Database;

namespace App06_Tarefas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();

            lblData.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd/MM/yyyy");

            CarregaTarefas();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }

        public void LinhaStackLayout(Tarefa tarefa, int index)
        {

            Image imgDelete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
                imgDelete.Source = ImageSource.FromFile("Resources/Delete.png");

            TapGestureRecognizer DeleteTap = new TapGestureRecognizer();

            DeleteTap.Tapped += delegate
            {
                new GerenciadorTarefa().Remover(index);
                CarregaTarefas();
            };

            imgDelete.GestureRecognizers.Add(DeleteTap);

            Image imgPrioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("p" + tarefa.Prioridade + ".png") };
            if (Device.RuntimePlatform == Device.UWP)
                imgPrioridade.Source = ImageSource.FromFile("Resources/p" + tarefa.Prioridade + ".png");

            View stackLabel = null;
            if (tarefa.DataFinalizacao == null)
            {
                stackLabel = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                stackLabel = new StackLayout() { VerticalOptions = LayoutOptions.Center, Spacing = 0,  HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)stackLabel).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray });
                ((StackLayout)stackLabel).Children.Add(new Label() { Text = "Finalizado em " + tarefa.DataFinalizacao.Value.ToString("dd/MM/yyyy - hh:mm") + "h", TextColor = Color.Gray, FontSize = 10 });
            }

            string imgName;
            if (tarefa.DataFinalizacao == null)
            {
                imgName = "CheckOff";
            }
            else
            {
                imgName = "CheckOn";
            }

            Image imgCheck = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(imgName + ".png")};
            if(Device.RuntimePlatform == Device.UWP)
                imgCheck.Source = ImageSource.FromFile("Resources/" + imgName + ".png");

            TapGestureRecognizer CheckTap = new TapGestureRecognizer();

            CheckTap.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(index, tarefa);
                CarregaTarefas();
            };

            imgCheck.GestureRecognizers.Add(CheckTap);

            StackLayout linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            linha.Children.Add(imgCheck);
            linha.Children.Add(stackLabel);
            linha.Children.Add(imgPrioridade);
            linha.Children.Add(imgDelete);

            SLTarefas.Children.Add(linha);

        }

        private void CarregaTarefas()
        {
            SLTarefas.Children.Clear();

            List<Tarefa> lista = new List<Tarefa>();
            GerenciadorTarefa gerenciador = new GerenciadorTarefa();
            lista = gerenciador.Listagem();
            int index = 0;
            foreach (Tarefa tarefa in lista)
            {
                LinhaStackLayout(tarefa, index);
                index++;
            } 
        }

    }
}