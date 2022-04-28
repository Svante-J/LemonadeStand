namespace LemonadeStand.Helpers
{
    public static class Calkulator
    {
        
        internal static double MoneyLeft(int orderedGlassQuantity, int pricePerGlass, int moneyPaid) 
        {
          return orderedGlassQuantity * pricePerGlass - moneyPaid;            
        }
    }
}
