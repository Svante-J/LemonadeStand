namespace LemonadeStand.Helpers
{
    public static class Calkulator
    {
        public static int BuyLemonade(int x,int y) => x - y;

        public static int LemonadesPrice(int Lemonades, int price) => Lemonades * price;
    }
}
