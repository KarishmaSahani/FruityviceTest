using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FruityviceTest.Models
{
    public class FruitFamilyRequest
    {
        
        [Required]
        public string FruitFamily { get; set; }
    }
}
