using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace KanyeAndWeatherExercise;

public class WeatherMap
{
    public static void GetWeather()
    {
        var jsontext = File.ReadAllText("appsettings.json");

        var apikey = JObject.Parse(jsontext).GetValue("key").ToString();
        
        Console.WriteLine("Enter ZipCode : ");

        var zipcode = Console.ReadLine();

        var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zipcode}&appid={apikey}&units=imperial";

        var client = new HttpClient();

        var jsonResponse = client.GetStringAsync(url).Result;

        var weatherObj = JObject.Parse(jsonResponse);
        
        Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");
        Console.WriteLine($"{weatherObj["weather"][0]["description"]}\nwind speed: {weatherObj["wind"]["speed"]}");
    }
}