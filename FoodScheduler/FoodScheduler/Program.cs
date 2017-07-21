using FoodScheduler.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScheduler
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                bool ContinueOrder = true;
                Console.WriteLine("Start Order.");
                Console.WriteLine("Morning Menu - Entree: Egg (Code:1), Side: Toast(Code:2), Drink: Coffee(Code:3 - More than 1 order allowed)");
                Console.WriteLine("Night Menu - Entree: Steak (Code:1), Side: Potato(Code:2 - More than 1 order allowed), Drink: Wine(Code:3), Drink: Dessert(Code:4)");
                Console.WriteLine("Please use the format [Time of Order],[Order ID] to place order Eg. morning,1 or night,1,2");
                while (ContinueOrder)
                {
                    Console.Write("Input:");
                    var orderInput = Console.ReadLine(); // read input
                    ContinueOrder = ExecuteOrder(orderInput, ContinueOrder);
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine("Unexpected Error occurred {0}", exp.Message);
            }

        }

        public static bool ExecuteOrder(string orderInput, bool continueOrder)
        {
            // build a food inventory and intialize orders
            var FoodInventory = LoadFoodInventory();

            if (!string.IsNullOrWhiteSpace(orderInput)) // Chech for empty orders
            {
                string[] values = orderInput.Split(',').Select(sValue => sValue.Trim()).ToArray();

                if (values[0].ToLower() != "morning" && values[0].ToLower() != "night")
                {
                    Console.WriteLine("Incorrect order format, please use [Time of Order],[Order ID] Eg. morning,1 or night,1,2");

                }
                else
                {
                    if (values.Length > 1) 
                    {
                        var orderTicket = OrderTicket.CreateOrderTicketFrom(orderInput);
                        var order = FoodInventory.ProcessOrder(orderTicket);
                        Console.WriteLine("Output: {0}", string.Join(",", order.Items.Select(GetDisplayOrderItem)));
                        Console.Write("Do you wish to continue? Press n to close :");
                        var YesNo = Console.ReadLine();
                        if (!String.IsNullOrEmpty(YesNo))
                        {
                            if (YesNo.ToLower() != "y")
                            {
                                continueOrder = false;
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Please select atleast one dish");

                    }
                }
            }
            else {
                Console.WriteLine("Invalid/Empty Order; Please use [Time of Order],[Order ID] Eg. morning,1 or night,1,2");
            }
            return continueOrder;
        }



        public static object GetDisplayOrderItem(OrderItem item)
        {
            return string.Format("{0}{1}", item.DishName.ToLower(),
                                item.Quantity > 1 ? string.Format("(x{0})", item.Quantity) : "");
        }

        public static FoodInventory LoadFoodInventory()
        {
            // morning inventory
            var morningItems = new List<MenuItem> { new MenuItem(DishType.Entree, new Dish("Eggs")),
                                                 new MenuItem(DishType.Side, new Dish("Toast")),
                                                 new MenuItem(DishType.Drink, new Dish("Coffee"), allowedItems:2) };
            //night inventory
            var nightItems = new List<MenuItem> { new MenuItem(DishType.Entree, new Dish("Steak")),
                                                 new MenuItem(DishType.Side, new Dish("Potato"),allowedItems:2),
                                                 new MenuItem(DishType.Drink, new Dish("Wine")),
                                                 new MenuItem(DishType.Desert, new Dish("Cake")) };

            //time of order morning/night
            var OrderTime = new Dictionary<string, IEnumerable<MenuItem>> { { "morning", morningItems }, { "night", nightItems } };

            return new FoodInventory(new Menu(OrderTime), new OrderTicketProcessor().ProcessOrderTicket);

        }
    }
}
