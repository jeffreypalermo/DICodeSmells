using System;

namespace DIAntiPattern
{
    public static class ObjectFactory
    {
        public static T GetInstance<T>()
        {
            if(typeof(T).Equals(typeof(IOrderProcessor)))
            {
                IOrderProcessor instance = new OrderProcessor(new OrderValidator(), new AccountsReceivable(), new RateExchange(), new UserContext());
                return (T) instance;
            }
            
            if(typeof(T).Equals(typeof(IOrderShipper)))
            {
                IOrderShipper shipper = new OrderShipper();
                return (T)shipper;
            }

            throw new NotImplementedException();
        }
    }
}