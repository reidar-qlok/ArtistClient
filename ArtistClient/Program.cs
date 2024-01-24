
using ArtistClient.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ArtistClient
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            
            await GetArtistsAsync();
            await AddArtistAsync(new Artist { ArtistName = "Reidar"});
        }

        static async Task GetArtistsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:7146/artists");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        
        static async Task AddArtistAsync(Artist artist)
        {
            try
            {
                var json = JsonSerializer.Serialize(artist);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:7096/artists", content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
