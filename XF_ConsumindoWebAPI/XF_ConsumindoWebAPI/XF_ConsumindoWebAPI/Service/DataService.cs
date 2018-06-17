using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XF_ConsumindoWebAPI.Models;

namespace XF_ConsumindoWebAPI.Service
{
    class DataService
    {
        HttpClient client = new HttpClient();

        public async Task<List<Produto>> GetProdutosAsync()
        {
            try
            {
                string url = "http://noronhasoft.somee.com/api/Produtos";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Produto>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddProdutoAsync(Produto produto)
        {
            try
            {
                string url = "http://noronhasoft.somee.com/api/Produtos/{0}";

                var uri = new Uri(string.Format(url, produto.Id));

                var data = JsonConvert.SerializeObject(produto);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir produto");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {

            string url = "http://noronhasoft.somee.com/api/Produtos/{0}";
            var uri = new Uri(string.Format(url, produto.Id));

            var data = JsonConvert.SerializeObject(produto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar o produto");
            }
        }

        public async Task DeletaProdutoAsync(Produto produto)
        {
            string url = "http://noronhasoft.somee.com/api/Produtos/{0}";
            var uri = new Uri(string.Format(url, produto.Id));
            await client.DeleteAsync(uri);
        }
    }
}
