using System.Text.Json.Serialization;

namespace FruityviceTest.Models
{
    public class Nutrition
    {
        [JsonPropertyName("carbohydrates")]
        public int Carbohydrates { get; set; }

        [JsonPropertyName("protein")]
        public int Protein { get; set; }

        [JsonPropertyName("fat")]
        public int Fat { get; set; }

        [JsonPropertyName("sugar")]
        public int Sugar { get; set; }

        [JsonPropertyName("calories")]
        public int Calories
        {
            get; set;
        }
    }
}
