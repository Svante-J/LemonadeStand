namespace LemonadeStand.Helpers
{
    public static class Calkulator
    {
        
        internal static double MoneyLeft(int orderedGlassQuantity, int pricePerGlass, int moneyPaid) 
        {
          return orderedGlassQuantity * pricePerGlass - moneyPaid;            
        }

        internal static decimal FruitsLeft(int count, decimal consumptionPerGlass, int orderedGlassQuantity)
        {
            
            return (decimal)Math.Round(count - (consumptionPerGlass * orderedGlassQuantity));
        }
    }
}
