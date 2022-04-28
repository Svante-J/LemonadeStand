using LemonadeStand.Controllers;
using LemonadeStand.Models;
using LemonadeStand.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Json;

namespace LemonadeStand.Components.Forms
{
    public class OrderFormModalBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        ILogger<LemonadeViewModel> Logger { get; set; }

        protected LemonadeViewModel lemonadeModel = new();

        protected CustomFormValidator customFormValidator;

        protected bool isRegistrationSuccess = false;


        protected async Task RegisterLemonade()
        {
            customFormValidator.ClearFormErrors();
            isRegistrationSuccess = false;
            try
            {
                var response = await Http.PostAsJsonAsync("api/LemonadeOrder", lemonadeModel );
                var errors = await response.Content.ReadFromJsonAsync<Dictionary<string, List<string>>>();

                FruitPressResult fruitPressResult = new FruitPressResult();
                IRecipe recipe;
                IFruit fruit;
                Collection<IFruit> fruitlist = new();
                decimal fruitsNeeded = 0;

                if (lemonadeModel.Lemonade.ToLower() == "apple lemonade")
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
                }


                               


                if (response.StatusCode == HttpStatusCode.BadRequest && errors.Count > 0)
                {
                    customFormValidator.DisplayFormErrors(errors);
                    throw new HttpRequestException($"Validation failed. Status Code: {response.StatusCode}");
                }
                else
                {
                    isRegistrationSuccess = true;
                    Logger.LogInformation("The registration is successful");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }
    }
}
