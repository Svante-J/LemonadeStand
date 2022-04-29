namespace LemonadeStand.Models
{    
        public class Orange : IFruit
        {
            public string Name { get; private set; } = "Orange";
        }

        public class OrangeLemonadeRecipe : IRecipe
        {
            public string Name { get; private set; } = "Orange Lemonade";

            public Type AllowedFruit { get; private set; } = typeof(Orange);

            public decimal ConsumptionPerGlass { get; private set; } = 1;

            public int PricePerGlass { get; private set; } = 9;


        }
    
}
