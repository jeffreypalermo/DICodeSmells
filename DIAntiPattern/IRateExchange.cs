namespace DIAntiPattern
{
    public interface IRateExchange
    {
        int Convert(int cents, Currency currency);
    }
}