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
        protected bool isRegistrationSuccess = true;
        protected string message = "Order calculations";

        protected async Task RegisterLemonade()
        {            
            
            try
            {               
                
                FruitPressResult fruitPressResult = new FruitPressResult();
                IRecipe recipe;
                IFruit fruit;
                Collection<IFruit> fruitlist = new();
                int orderdGlassQty = lemonadeModel.Quantity;
                

                if (lemonadeModel.Lemonade.ToLower() == "apple lemonade")                
                    fruitPressResult = PreProduceApple(fruitPressResult, out recipe, out fruit, fruitlist);
                if (lemonadeModel.Lemonade.ToLower() == "watermelon lemonade")
                    fruitPressResult = PreProduceMelon(fruitPressResult, out recipe, out fruit, fruitlist);
                if (lemonadeModel.Lemonade.ToLower() == "orange lemonade")
                    fruitPressResult = PreProduceOrange(fruitPressResult, out recipe, out fruit, fruitlist);
                

                if (fruitPressResult.IsPressSucces)
                {
                    message = fruitPressResult.Message;
                    Logger.LogInformation("The registration is successful");
                    isRegistrationSuccess = true;
                }
                else
                {
                    message = fruitPressResult.Message;
                    Logger.LogInformation("The registration failed");
                    isRegistrationSuccess = false;
                }
                                               
                
            }


            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }
               
     
        private FruitPressResult PreProduceApple(FruitPressResult fruitPressResult, out IRecipe recipe, out IFruit fruit, Collection<IFruit> fruitlist)
        {
            fruit = new Apple();
            recipe = new AppleLemonadeRecipe();
            
            for (int i = 0; i < lemonadeModel.ApplesAdded; i++)
            {
                fruitlist.Add(fruit);
            }
           
            fruitPressResult = fruitPressResult.Produce
                (recipe, fruitlist, lemonadeModel.MoneyPaid, lemonadeModel.Quantity);
            return fruitPressResult;
        }
        private FruitPressResult PreProduceMelon(FruitPressResult fruitPressResult, out IRecipe recipe, out IFruit fruit, Collection<IFruit> fruitlist)
        {
            fruit = new Watermelon();
            recipe = new WatermelonLemonadeRecipe();

            for (int i = 0; i < lemonadeModel.MelondAdded; i++)
            {
                fruitlist.Add(fruit);
            }

            fruitPressResult = fruitPressResult.Produce
                (recipe, fruitlist, lemonadeModel.MoneyPaid, lemonadeModel.Quantity);
            return fruitPressResult;
        }
        private FruitPressResult PreProduceOrange(FruitPressResult fruitPressResult, out IRecipe recipe, out IFruit fruit, Collection<IFruit> fruitlist)
        {
            fruit = new Orange();
            recipe = new OrangeLemonadeRecipe();

            for (int i = 0; i < lemonadeModel.OrangeAdded; i++)
            {
                fruitlist.Add(fruit);
            }

            fruitPressResult = fruitPressResult.Produce
                (recipe, fruitlist, lemonadeModel.MoneyPaid, lemonadeModel.Quantity);
            return fruitPressResult;
        }
    }
}
