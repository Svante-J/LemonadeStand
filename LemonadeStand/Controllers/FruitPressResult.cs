using LemonadeStand.Helpers;
using LemonadeStand.Models;
using System.Collections.ObjectModel;
using System.Text;

namespace LemonadeStand.Controllers
{
    public class FruitPressResult : IFruitPressService
    {
        public bool IsPressSucces { get; set; }
        public bool IsMoneyBiggerThanCost { get; set; }
        public bool IsFruitBiggerThanConsum { get; set; }   
        public string Message { get; set; }
        public List <string> Messages { get; set; }
       

        public FruitPressResult Produce(IRecipe recipe, Collection<IFruit> fruits, int moneyPaid, int orderedGlassQuantity)
        {
            FruitPressResult result = new FruitPressResult();
            result.IsPressSucces = false;
            var moneyLeft = Calkulator.MoneyLeft(orderedGlassQuantity, recipe.PricePerGlass, moneyPaid);
            var fruitsLeft = Calkulator.FruitsLeft(fruits.Count, recipe.ConsumptionPerGlass, orderedGlassQuantity);
            if (moneyLeft >= 0 && fruitsLeft >= 0)
            { 
                result.IsPressSucces = true;
                result.Message = 
                    @$"The Costumer should have {moneyLeft} back in change. " +   
                    @$" Putt {fruitsLeft} {recipe.AllowedFruit.Name}s back in your basket";
            }
            else
            {
                StringBuilder builder = new StringBuilder(); 
                if (moneyLeft < 0)
                {
                    //result.Message = "Ops! your customer need to pay " + Math.Abs(moneyLeft) + " more.";
                    builder.Append("Ops! your customer need to pay " + Math.Abs(moneyLeft) + " more. ");
                }
                if (fruitsLeft < 0)
                {
                    
                    builder.Append("Putt " + Math.Abs(fruitsLeft) + " more " + recipe.AllowedFruit.Name + "s in your blender.");
                }
                result.IsPressSucces = false;
                result.Message = builder.ToString();
            }
            return result;
        }

        
    }
}
