namespace LemonadeStand.Models
{
    public class Apple : IFruit 
    {
        public string Name { get; private set; } = "Apple";
    }

    public class AppleLemonadeRecipe : IRecipe
    {
        public string Name { get; private set; } = "Apple Lemonade";

        public Type AllowedFruit { get; private set; } = typeof(Apple);

        public decimal ConsumptionPerGlass { get; private set; } = 2;

        public int PricePerGlass { get; private set; } = 9;
    }
}
