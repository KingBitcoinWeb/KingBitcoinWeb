using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using RestSharp;

namespace RequisicoesWeb
{
    class GET_ValorBTC
    {
        public static void Main(string[] args)
        {

            //EnviaRequisicaoPOST();  
            EnviaRequisicaoGET_BTC();
        }

        public static void EnviaRequisicaoGET_BTC()
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://www.mercadobitcoin.net/api/BTC/ticker/");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";


            //APARECE TODOS OS DADOS NA TELA
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                Console.WriteLine(objResponse.ToString());
                Console.ReadLine();
                streamDados.Close();
                resposta.Close();
            }


            /*using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var dadosBTC = JsonConvert.DeserializeObject<DadosBTC>(objResponse.ToString());
                Console.WriteLine(dadosBTC.buy);
                //Console.WriteLine(post.Id + " " + post.title + " " + post.body);
                Console.ReadLine();
                streamDados.Close();
                resposta.Close();
            }
            Console.ReadLine();
        */
        }
    }


}

