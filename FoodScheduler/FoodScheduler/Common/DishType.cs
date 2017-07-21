using System;
using System.Linq;

namespace FoodScheduler.Common
{
    public class DishType
    {
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public int ServiceOrder { get; set; }

        public DishType(int categoryID, string category, int serviceOrder)
        {
            CategoryID = categoryID;
            Category = category;
            ServiceOrder = serviceOrder;
        }


        public static DishType Entree = new DishType(1, "Entree", 1);
        public static DishType Side = new DishType(2, "Side", 2);
        public static DishType Drink = new DishType(3, "Drink", 3);
        public static DishType Desert = new DishType(4, "Desert", 4);
        public static DishType UnListed = new DishType(5, "Unlisted", 5);

        public static DishType GetByCategoryID(string categoryID)
        {
            int catID = 0;
            if (Int32.TryParse(categoryID, out catID))
            {
                var CategoryTypeList = new[] { Entree, Side, Drink, Desert };
                var categoryType = CategoryTypeList.FirstOrDefault(d => d.CategoryID == catID);
                return categoryType ?? UnListed;
            }
            else {
                return UnListed;
            }    
        }
    }
}