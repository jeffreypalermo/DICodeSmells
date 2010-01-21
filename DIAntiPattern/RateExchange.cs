namespace DIAntiPattern
{
    public class RateExchange : IRateExchange
    {
        public int Convert(int cents, Currency currency)
        {
            return 45;
        }
    }
}