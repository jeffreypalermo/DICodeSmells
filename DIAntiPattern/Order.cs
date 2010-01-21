using System;

namespace DIAntiPattern
{
    public class Order
    {
        public DateTime Placed { get; set; }
        public string OtherInfo { get; set; }
        public Price GetPrice(IRateExchange exchange, IUserContext userContext)
        {
            User currentUser = userContext.GetCurrentUser();
            Currency currency = userContext.GetSelectedCurrency(currentUser);
            int priceInSelectedCurrency = exchange.Convert(GetPrice(), currency);
            var price = new Price{Currency = currency, Value = priceInSelectedCurrency};
            return price;
        }

        private int GetPrice()
        {
            //do work to aggregate prices from line items, and total up order.
            return 1000;
        }
    }
}