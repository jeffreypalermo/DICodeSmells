namespace DIAntiPattern
{
    public interface IOrderProcessor
    {
        SuccessResult Process(Order order);
    }
}