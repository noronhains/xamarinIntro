using System;
using System.Net;
using SQLite;
using System.IO;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace xamarinSQLiteToJson
{
    class AcessoBD : IDisposable
    {
        private SQLiteConnection conexaoSQLite;

        public AcessoBD(){
            var config = DependencyService.Get<IConfig>();
            conexaoSQLite = new SQLiteConnection(Path.Combine(config.DiretorioSQLite, "Cadastro.db3"));
            conexaoSQLite.CreateTable<Cliente>();
        }

        public void InserirCliente(Cliente cliente)
        {
            conexaoSQLite.Insert(cliente);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            conexaoSQLite.Update(cliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
            conexaoSQLite.Delete(cliente);
        }

        public Cliente GetCliente(int codigo)
        {
            return conexaoSQLite.Table<Cliente>().FirstOrDefault(c => c.Id == codigo);
        }

        public List<Cliente> GetClientes()
        {
            return conexaoSQLite.Table<Cliente>().OrderBy(c => c.Nome).ToList();
        }

        public bool ExportaJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(GetClientes());
                String sandbox = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string jsonPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "expDados.json");
                File.WriteAllText(jsonPath, json);


                if (!string.IsNullOrEmpty(jsonPath))
                {
                    string urlArquivoEnviar = "ftp://ftp.softwale.com.br" + "/testes/" + "expDados.json";
                            FTP.EnviarArquivoFTP(jsonPath, urlArquivoEnviar, "usuario", "senha");
                }
                else
                {
                    
                }

                return true;
            }catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
        
        public void Dispose()
        {
            conexaoSQLite.Dispose();
        }

    }
}
