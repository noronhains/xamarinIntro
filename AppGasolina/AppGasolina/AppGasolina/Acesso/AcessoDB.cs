using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Xamarin.Forms;
using AppGasolina.Models;

namespace AppGasolina
{
    class AcessoDB : IDisposable
    {
        private SQLiteConnection conexaoSQLite;

        public AcessoDB()
        {
            var config = DependencyService.Get<IConfig>();
            conexaoSQLite = new SQLiteConnection(Path.Combine(config.DiretorioSQLite, "Abastecimento.db3"));
            conexaoSQLite.CreateTable<Abastecimento>();
        }

        public void InserirAbastecimento(Abastecimento abastecimento)
        {
            conexaoSQLite.Insert(abastecimento);
        }

        public void AtualizarAbastecimento(Abastecimento abastecimento)
        {
            conexaoSQLite.Update(abastecimento);
        }

        public void DeletarAbastecimento(int codigo)
        {
            conexaoSQLite.Table<Abastecimento>().Delete(c => c.Id == codigo);
        }

        public Abastecimento GetAbastecimento(int codigo)
        {
            return conexaoSQLite.Table<Abastecimento>().FirstOrDefault(c => c.Id == codigo);
        }

        public List<Abastecimento> GetAbastecimentos()
        {
            return conexaoSQLite.Table<Abastecimento>().OrderBy(c => c.Data).ToList();
        }

        public int UltimoCodigo()
        {
            List<Abastecimento> Lista = conexaoSQLite.Table<Abastecimento>().OrderBy(c => c.Id).ToList();

            int maior = 0;

            foreach(Abastecimento i in Lista)
            {
                if(i.Id > maior)
                {
                    maior = i.Id;
                }
            }

            return maior;
        }

        public void Dispose()
        {
            conexaoSQLite.Dispose();
        }
    }
}
