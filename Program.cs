using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace TestOnellect
{
    public class Program
    {
        private static readonly HttpClient httpClient = new();
        static async Task Main(string[] args)
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                var url = config.GetSection("Url").Value;

                Random r = new();
                SortMethods sortMethods = new();
                var list = new List<int>();
                var count = r.Next(20, 101);

                for (var i = 0; i < count; i++)
                    list.Add(r.Next(-100, 101));

                Console.WriteLine(string.Join(" ", list));

                sortMethods.RandomSort(list);

                Console.WriteLine(string.Join(" ", list));

                StringContent jsonContent = new(
                    JsonSerializer.Serialize(list),
                    Encoding.UTF8,
                    "application/json");

                using var response = await httpClient.PostAsync(url ,jsonContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
