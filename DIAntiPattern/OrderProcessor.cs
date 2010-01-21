namespace DIAntiPattern
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderValidator _validator;

        public OrderProcessor(IOrderValidator validator)
        {
            _validator = validator;
        }

        public SuccessResult Process(Order order)
        {
            bool isValid = _validator.Validate(order);
            if (isValid)
            {
                IOrderShipper shipper = new OrderShipperFactory().GetDefault();
                shipper.Ship(order);
            }

            return CreateStatus(isValid);
        }

        private SuccessResult CreateStatus(bool isValid)
        {
            return isValid ? SuccessResult.Success : SuccessResult.Failed;
        }
    }
}