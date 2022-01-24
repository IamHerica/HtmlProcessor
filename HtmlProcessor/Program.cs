using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;

namespace HtmlProcessor
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:/Users/heric/Downloads/TesteConsole/listadeacoes.txt");
                var doc = new HtmlWeb().Load("https://www.infomoney.com.br/cotacoes/empresas-b3/");
                var acoes = doc.DocumentNode.Descendants().Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("strong"));
                foreach (var acao in acoes)
                {
                    sw.Write(acao.InnerText);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Verifique a pasta Downloads, a saída de seu programa está lá.");
            }

        }
    }
}
