using FruityviceTest.Interfaces;
using FruityviceTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FruityviceTest.Repository
{
    public class FruitService : IFruitService
    {
        private readonly string _baseUrl = "https://www.fruityvice.com/api/fruit";
       // public HttpClient _httpClient { get; set; }

        public IHttpClientFactory _httpClientFactory { get; set; }
        public ILogger _logger { get; set; }
        public FruitService(IHttpClientFactory httpClientFactory, ILogger<FruitService> logger) {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        /// <summary>
        /// Get all the Fruits from FruityVide service
        /// </summary>
        /// <returns>List of Fruits</returns>
        public async Task <List<Fruit> >GetAllFruits()
        {
            try
            {
                var httpclient = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await httpclient.GetAsync($"{_baseUrl}/all");
                if (response.IsSuccessStatusCode)
                {

                    var stream = await response.Content.ReadAsStreamAsync();
                    var fruits = await JsonSerializer.DeserializeAsync<List<Fruit>>(stream);
                    return fruits;
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex.ToString(),"Error while retrieving Fruits");
            }      
            return new List<Fruit>();

        }

        /// <summary>
        /// Returns List of Fruits that belong to input fruit family
        /// </summary>
        /// <param name="family"></param>
        /// <returns>list of fruits</returns>
        public async Task<List<Fruit>> GetFruitsByFamily(string family)
        {
            try
            {
                var httpclient = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await httpclient.GetAsync($"{_baseUrl}/family/{family}");
                if (response.IsSuccessStatusCode)
                {

                    var stream = await response.Content.ReadAsStreamAsync();
                    var fruits = await JsonSerializer.DeserializeAsync<List<Fruit>>(stream);
                    return fruits;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString(), "Error while retrieving Fruits");
            }
            return new List<Fruit>();

        }

    }
}
