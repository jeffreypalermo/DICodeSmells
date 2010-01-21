namespace DIAntiPattern
{
    public class OrderValidator : IOrderValidator
    {
        public bool Validate(Order order)
        {
            return false; //hard-coding just for example's sake.
        }
    }
}