namespace LemonadeStand.Helpers
{
    public static class Calkulator
    {
        
        internal static double MoneyLeft(int orderedGlassQuantity, int pricePerGlass, int moneyPaid) 
        {
          return moneyPaid - (orderedGlassQuantity * pricePerGlass);            
        }

        internal static decimal FruitsLeft(int count, decimal consumptionPerGlass, int orderedGlassQuantity)
        {
            
            return Math.Round(count - (consumptionPerGlass * orderedGlassQuantity) , 1);
        }
    }
}
