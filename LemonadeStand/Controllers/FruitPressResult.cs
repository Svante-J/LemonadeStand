using LemonadeStand.Helpers;
using LemonadeStand.Models;
using System.Collections.ObjectModel;

namespace LemonadeStand.Controllers
{
    public class FruitPressResult : IFruitPressService
    {
        public bool IsPressSucces { get; set; }
        public bool IsMoneyBiggerThanCost { get; set; }
        public bool IsFruitBiggerThanConsum { get; set; }   
        public string Message { get; set; }
        //Object Recipe { get; set; }

        public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
        {
            FruitPressResult result = new FruitPressResult();

            var moneyLeft = Calkulator.MoneyLeft(orderedGlassQuantity, recipe.PricePerGlass, moneyPaid);
            var fruitsLeft = Calkulator.FruitsLeft(fruits.Count, recipe.ConsumptionPerGlass, orderedGlassQuantity);
            if (moneyLeft >= 0 || fruitsLeft >= 0)
            { 
                IsPressSucces = true;
                Message = @$"Moneleft = {moneyLeft}" + @$"Fruitsleft = {fruitsLeft}";
            }
            else
            {
                IsPressSucces = false;
                Message = "naaaaaa";
            }
            return result;
        }

        public string CollectedMessage()
        {

            return null;
        }
        public string GetErrorMsg() => Message;
        public bool GetPressSucces() => IsPressSucces;

        
    }
}
