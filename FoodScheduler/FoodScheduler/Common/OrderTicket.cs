using System.Collections.Generic;
using System.Linq;

namespace FoodScheduler.Common
{
    public class OrderTicket
    {
        public string TimeOfDay { get; set; }
        public IEnumerable<DishType> Dishes { get; set; }
        public OrderTicket(string timeOfDay, IEnumerable<DishType> dishes)
        {
            TimeOfDay = timeOfDay;
            Dishes = dishes;
        }
        public static OrderTicket CreateOrderTicketFrom(string orderInput)
        {
            var split = orderInput.Split(',');
            var timeOfDay = split[0].Trim().ToLower();
            var dishTypes = split.Skip(1).Select(DishType.GetByCategoryID).ToList();
            return new OrderTicket(timeOfDay, dishTypes);
        }
    }
}