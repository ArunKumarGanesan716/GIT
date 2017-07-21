using System.Collections.Generic;
using System.Linq;

namespace FoodScheduler.Common
{
    public class Order
    {
        IEnumerable<OrderItem> _items;
        public IEnumerable<OrderItem> Items
        {
            get
            {
                return _items.OrderBy(i => i.FoodMakingOrder);
            }
        }

        public void AddItems(IEnumerable<OrderItem> orderItems)
        {
            _items = orderItems;
        }
        public bool HasError
        {
            get { return _items.Any(i => i == OrderItem.ErrorItem); }
        }
    }
}