﻿using System;
using System.Collections.Generic;

namespace DIAntiPattern
{
    public class Program
    {
        public static void Main()
        {
            ConfigureFactories();

            DateTime startTime = DateTime.Now;
            Console.WriteLine("Begin: " + startTime.TimeOfDay);
            IEnumerable<Order> orders = GetNextTenOrders();

            foreach (var order in orders)
            {
                IOrderProcessor processor =
                    ObjectFactory.GetInstance<IOrderProcessor>();
                SuccessResult successResult = processor.Process(order);
                if (successResult == SuccessResult.Success)
                {
                    RecordSuccess(order);
                    continue;
                }

                ReportFailure(order);
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("End:   " + endTime.TimeOfDay);
            Console.WriteLine("Total time: " + endTime.Subtract(startTime));
        }

        private static void ConfigureFactories()
        {
            OrderShipperFactory.CreationClosure =
                () => ObjectFactory.GetInstance<IOrderShipper>();
        }

        private static void ReportFailure(Order order)
        {
            //no-op - demo
        }

        private static void RecordSuccess(Order order)
        {
            //no-op - demo
        }

        private static IEnumerable<Order> GetNextTenOrders()
        {
            var list = new List<Order>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Order());
            }

            return list.ToArray();
        }
    }
}