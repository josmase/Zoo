namespace Zoo
{
    public class Prices
    {
        public Prices(double fruits, double meat)
        {
            Fruits = fruits;
            Meat = meat;
        }

        public double Meat { get; }
        public double Fruits { get; }
    }
}