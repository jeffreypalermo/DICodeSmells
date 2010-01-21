using System;

namespace DIAntiPattern
{
    public class OrderShipperFactory
    {
        public static Func<IOrderShipper> CreationClosure;
        public IOrderShipper GetDefault()
        {
            return CreationClosure();//executes closure
        }
    }
}