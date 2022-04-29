namespace LemonadeStand.Models
{
    public class Watermelon : IFruit
    {
        public string Name { get; private set; } = "WaterMelon";
    }
    
    public class WatermelonLemonadeRecipe : IRecipe
    {
        public string Name { get; private set; } = "Watermelon Lemonade";

        public Type AllowedFruit { get; private set; } = typeof(Watermelon);

        public decimal ConsumptionPerGlass { get; private set; } = 0.5M;

        public int PricePerGlass { get; private set; } = 12;


    }
}
