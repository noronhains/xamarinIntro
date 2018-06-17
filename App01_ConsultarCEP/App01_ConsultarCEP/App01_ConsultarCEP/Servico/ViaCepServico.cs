using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
namespace App01_ConsultarCEP.Servico
{
    class ViaCepServico
    {

        private static readonly string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);
            string error = "";
            WebClient wc = new WebClient();

            try
            {
                string conteudo = wc.DownloadString(novoEnderecoURL);
                
                Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

                if (end.Cep == null) { return null; }

                return end;

            }catch(Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
