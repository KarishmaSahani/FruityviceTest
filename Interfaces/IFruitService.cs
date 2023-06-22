using FruityviceTest.Models;

namespace FruityviceTest.Interfaces
{
    public interface IFruitService
    {
        Task<List<Fruit>> GetFruitsByFamily(string family);
        Task<List<Fruit>> GetAllFruits();
    }
}
