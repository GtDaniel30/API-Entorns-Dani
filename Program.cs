
using Newtonsoft.Json;
internal class Program
{
    private static void Main(string[] args)
    {

        do
        {
            string url = "https://api.wheretheiss.at/v1/satellites/25544";


            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            var APIISS = JsonConvert.DeserializeObject<Position>(jsonResponse);

            string latitude = APIISS.latitude;
            string longitude = APIISS.longitude;

            System.Console.WriteLine($"Latitud ahora mismo: {latitude}");
            System.Console.WriteLine($"Longitud ahora mismo: {longitude}");


            string urlpais = $"http://api.geonames.org/countrycodeJSON?lat={latitude}&lng={longitude}&username=marc";


            HttpClient whereis = new HttpClient();

            HttpResponseMessage respuesta = client.GetAsync(urlpais).Result;
            string jsonrespuesta = respuesta.Content.ReadAsStringAsync().Result;

            var whreiss = JsonConvert.DeserializeObject<Country>(jsonrespuesta);


            System.Console.WriteLine($"Actualmente estan en : {whreiss.countryName}");

            Thread.Sleep(10000);

        } while (true);


    }

    public class Position
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Country
    {
        public string countryName { get; set; }
    }


}