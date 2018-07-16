using System;
using System.Collections.Generic;
using System.Text;
using App06_Tarefas.Models;
namespace App06_Tarefas.Database
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }

        public void Salvar(Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.Add(tarefa);
            SalvarProperties(Lista);
        }

        public void Remover(Tarefa tarefa)
        {
            Lista.Remove(tarefa);
            SalvarProperties(Lista);
        }

        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);
            Lista.Add(tarefa);
            SalvarProperties(Lista);
        }

        public List<Tarefa> Listagem()
        {
            return ListagemProperties();
        }

        private void SalvarProperties(List<Tarefa> lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }
            App.Current.Properties.Add("Tarefas", Lista);
        }
        
        private List<Tarefa> ListagemProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }
            return new List<Tarefa>();
        }

    }
}
