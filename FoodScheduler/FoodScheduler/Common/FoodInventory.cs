using System;

namespace FoodScheduler.Common
{
    public delegate Order ProcessOrder(Menu menu, OrderTicket Olist);

    public class FoodInventory
    {
        
        readonly Menu _menu;
        readonly ProcessOrder _processOrder;

       
        public FoodInventory(Menu menu, ProcessOrder processOrder)
        {
            _menu = menu;
            _processOrder = processOrder;
        }

        public Order ProcessOrder(OrderTicket Olist)
        {
            return _processOrder(_menu, Olist);
        }
    }
}