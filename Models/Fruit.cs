using System.Text.Json.Serialization;

namespace FruityviceTest.Models
{
    public class Fruit
    {
        [JsonPropertyName("genus")]
        public string Genus { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("family")]
        public string Family { get; set; }
        [JsonPropertyName("order")]
        public string Order { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nutrition")]

        public Nutrition Nutrition { get; set; }  
    }

}
