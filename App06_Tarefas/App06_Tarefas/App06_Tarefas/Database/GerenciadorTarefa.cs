using System;
using System.Collections.Generic;
using System.Text;
using App06_Tarefas.Models;
using Newtonsoft.Json;
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

        public void Remover(int index)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);
            SalvarProperties(Lista);
        }

        public void Finalizar(int index, Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);
            if (tarefa.DataFinalizacao == null)
            {
                tarefa.DataFinalizacao = DateTime.Now;
            }
            else
            {
                tarefa.DataFinalizacao = null;
            }
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

            string JsonVal = JsonConvert.SerializeObject(lista);

            App.Current.Properties.Add("Tarefas", JsonVal);
        }
        
        private List<Tarefa> ListagemProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string JsonVal = (string)App.Current.Properties["Tarefas"];
                List<Tarefa> lista = JsonConvert.DeserializeObject<List<Tarefa>>(JsonVal);
                return lista;
            } 
            return new List<Tarefa>();
        }

    }
}
