using System;
using System.Threading;

namespace DIAntiPattern
{
    public class OrderShipper : IOrderShipper
    {
        public OrderShipper()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(777));
        }

        public void Ship(Order order)
        {
            //ship the order
        }
    }
}