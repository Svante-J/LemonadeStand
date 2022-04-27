using LemonadeStand.Controllers;
using System.Collections.ObjectModel;

namespace LemonadeStand.Models
{
    
    public interface IFruit
    {
        string Name { get; }

        
    }
    public interface IRecipe
    {
        string Name { get; }
        Type AllowedFruit { get; }
        decimal ConsumptionPerGlass { get; }
        int PricePerGlass { get; }
    }
    public interface IFruitPressService
    {
        FruitPressResult Produce(IRecipe recipe,
        Collection<IFruit> fruits, int moneyPaid, int
        orderedGlassQuantity);
    }
    
}
