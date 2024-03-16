using HtmlAgilityPack;
using System;
using System.Net.Http;


namespace WebScraper
{
    class Program
    {
        static void Main(String[] args)
        {
            try
            {
                string url = "https://www.metacritic.com/game/ghost-of-tsushima-directors-cut/";
                var httpClient = new HttpClient();
                var html = httpClient.GetStringAsync(url).Result; 
                var htmlDocument = new HtmlDocument(); 

                htmlDocument.LoadHtml(html);

                // Titulo
                var titleElement = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"__layout\"]/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[1]/div");
                var title = titleElement?.InnerText?.Trim(); 

                if(title != null)
                {
                    Console.WriteLine("Título do jogo: " + title);
                }
                else
                {
                    Console.WriteLine("Título não encontrado"); 
                }


                var criticElement = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"__layout\"]/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[4]/div[1]/div/div[1]/div[2]/div/div/span");
                var critic = criticElement?.InnerText?.Trim();

                if(critic != null) {

                    Console.WriteLine("Nota dos críticos é igual a: " + critic);

                }

                else
                {
                    Console.WriteLine("Nota dos críticos não foi encontrada: ");
                }


                var userElement = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"__layout\"]/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[4]/div[2]/div[1]/div[2]/div/div/span");
                var user = userElement?.InnerText?.Trim();

                if (user != null)
                {
                    Console.WriteLine("Nota dos usuários é igual a: " + user);
                }

                else
                {
                    Console.WriteLine("Nota dos usuários não foram encontradas");
                }



            }







            catch (HttpRequestException e) 
            { 
                Console.WriteLine("Error Fetching URL: " + e.Message);
            }
            catch (Exception ex) {

                Console.WriteLine("An error occurred" + ex.Message);
                
            }
        }
    }
}