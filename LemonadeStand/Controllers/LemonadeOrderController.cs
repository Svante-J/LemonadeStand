
using LemonadeStand.Models;
using LemonadeStand.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace LemonadeStand.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class LemonadeOrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LemonadeViewModel registrationData)
        {
            FruitPressResult fruitPressResult = new FruitPressResult();
            IRecipe recipe;
            IFruit fruit;            
            Collection<IFruit> fruitlist = new();
            decimal fruitsNeeded=0;

            if (registrationData.Lemonade.ToLower() == "apple lemonade")
            {
                
                fruit = new Apple();
                recipe = new AppleLemonadeRecipe();              
               fruitsNeeded = (registrationData.Quantity * recipe.ConsumptionPerGlass);
                for (int i = 0; i < (fruitsNeeded) ; i++)
                {

                    fruitlist.Add(fruit);
                }
                fruitPressResult = fruitPressResult.Produce
                    (recipe, fruitlist, registrationData.MoneyPaid, registrationData.Quantity);
            }
                
               
                        
            if (fruitPressResult.PressSucces)
            {
                ModelState.AddModelError(nameof(registrationData.Lemonade), "This User Name is not available.");
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(ModelState);
            }
        }

        
    }
}
