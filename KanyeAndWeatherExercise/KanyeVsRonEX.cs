using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace KanyeAndWeatherExercise
{
    public class KanyeVsRonAPI
    {
        public static void Convo()
        {
            var client = new HttpClient();

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Kanye:\n {GetKanyeQuote(client)}\n");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(500);
                Console.WriteLine("...");
                Thread.Sleep(500);
                Console.WriteLine("...");
                Console.WriteLine($"Ron:\n{GetRonQuote(client)}\n");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(500);
                Console.WriteLine("...");
                Thread.Sleep(500);
                Console.WriteLine("...");
            }
        }
        
        public static string GetKanyeQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://api.kanye.rest/").Result;

            var quote = JObject.Parse(jsonText).GetValue("quote").ToString();

            return quote;
        }


        public static string GetRonQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            var quote = jsonText.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').ToString();

            return quote;
        }
    }
}
