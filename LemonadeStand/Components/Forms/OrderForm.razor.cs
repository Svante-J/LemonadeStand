using LemonadeStand.Controllers;
using LemonadeStand.Models;
using LemonadeStand.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Json;

namespace LemonadeStand.Components.Forms
{
    public class OrderFormModalBase : ComponentBase    {
        

        [Inject]
        ILogger<LemonadeViewModel> Logger { get; set; }

        protected LemonadeViewModel lemonadeModel = new();        

        protected bool isRegistrationSuccess = false;
        protected string succesMsg = "Rendera meag";

        protected async Task RegisterLemonade()
        {
            
            isRegistrationSuccess = false;
            try
            {               
                
                FruitPressResult fruitPressResult = new FruitPressResult();
                IRecipe recipe;
                IFruit fruit;
                Collection<IFruit> fruitlist = new();
                decimal fruitsNeeded = 0;

                if (lemonadeModel.Lemonade.ToLower() == "apple lemonade")                
                    fruitPressResult = ProduceApple(fruitPressResult, out recipe, out fruit, fruitlist, out fruitsNeeded);
                if (lemonadeModel.Lemonade.ToLower() == "watermelon lemonade")
                    fruitPressResult = ProduceApple(fruitPressResult, out recipe, out fruit, fruitlist, out fruitsNeeded);
                if (lemonadeModel.Lemonade.ToLower() == "orange lemonade")
                    fruitPressResult = ProduceApple(fruitPressResult, out recipe, out fruit, fruitlist, out fruitsNeeded);

                //string anotherMsg = FruitPressResult.HandleOrder(fruitPressResult);

                if (fruitPressResult.IsPressSucces)
                {
                    succesMsg = fruitPressResult.Message;
                }
                else
                {
                    succesMsg = fruitPressResult.GetErrorMsg();
                }
                Logger.LogInformation("The registration is successful");

                
                isRegistrationSuccess = true;


            }


            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }

        private FruitPressResult ProduceApple(FruitPressResult fruitPressResult, out IRecipe recipe, out IFruit fruit, Collection<IFruit> fruitlist, out decimal fruitsNeeded)
        {
            fruit = new Apple();
            recipe = new AppleLemonadeRecipe();
            fruitsNeeded = (lemonadeModel.Quantity * recipe.ConsumptionPerGlass);
            for (int i = 0; i < (fruitsNeeded); i++)
            {

                fruitlist.Add(fruit);
            }
            fruitPressResult = fruitPressResult.Produce
                (recipe, fruitlist, lemonadeModel.MoneyPaid, lemonadeModel.Quantity);
            return fruitPressResult;
        }
    }
}
