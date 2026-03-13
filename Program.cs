using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        do
        {
            string url = "https://api.open-meteo.com/v1/forecast?latitude=41.38879&longitude=2.15899&current_weather=true";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            var APIWeather = JsonConvert.DeserializeObject<Root>(jsonResponse);

            double temperature = APIWeather.current_weather.temperature;
            double windspeed = APIWeather.current_weather.windspeed;

            System.Console.WriteLine($"Temperatura en BCN ahora mismo: {temperature}°C");
            System.Console.WriteLine($"Viento en BCN ahora mismo: {windspeed} km/h");

            Thread.Sleep(1000);

        } while (true);
    }

    public class Root
    {
        public CurrentWeather current_weather { get; set; }
    }

    public class CurrentWeather
    {
        public double temperature { get; set; }
        public double windspeed { get; set; }
    }
}
