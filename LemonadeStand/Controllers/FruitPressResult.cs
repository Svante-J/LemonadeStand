using LemonadeStand.Helpers;
using LemonadeStand.Models;
using System.Collections.ObjectModel;

namespace LemonadeStand.Controllers
{
    public class FruitPressResult : IFruitPressService
    {
        public bool PressSucces { get; set; }
        bool MoneyBiggerThanCost { get; set; }
        string ErrorMsg { get; set; }
        //Object Recipe { get; set; }

        public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
        {
            FruitPressResult result = new FruitPressResult();

            double moneyleft = Calkulator.MoneyLeft(orderedGlassQuantity, recipe.PricePerGlass, moneyPaid);
                        
            return result;
        }

        public string CollectedMessage()
        {

            return null;
        }
        public string GetErrorMsg() => ErrorMsg;
        public bool GetPressSucces() => PressSucces;

        internal static string HandleOrder(FruitPressResult fruitPressResult)
        {
            retun null;
        }
    }
}
