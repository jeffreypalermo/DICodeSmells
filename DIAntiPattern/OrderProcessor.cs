namespace DIAntiPattern
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderValidator _validator;
        private readonly IAccountsReceivable _receivable;
        private readonly IRateExchange _exchange;
        private readonly IUserContext _userContext;

        public OrderProcessor(IOrderValidator validator,
                              IAccountsReceivable receivable,
                              IRateExchange exchange, IUserContext userContext)
        {
            _validator = validator;
            _receivable = receivable;
            _exchange = exchange;
            _userContext = userContext;
        }

        public SuccessResult Process(Order order)
        {
            bool isValid = _validator.Validate(order);
            if (isValid)
            {
                Collect(order);
                IOrderShipper shipper = new OrderShipperFactory().GetDefault();
                shipper.Ship(order);
            }

            return CreateStatus(isValid);
        }

        private void Collect(Order order)
        {
            User user = _userContext.GetCurrentUser();
            Price price = order.GetPrice(_exchange, _userContext);
            _receivable.Collect(user, price);
        }

        private SuccessResult CreateStatus(bool isValid)
        {
            return isValid ? SuccessResult.Success : SuccessResult.Failed;
        }
    }
}