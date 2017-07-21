
using System.Collections.Generic;

namespace FoodScheduler.Common
{
    public  class Menu
    {
        readonly Dictionary<string, IEnumerable<MenuItem>> _menuItems;

        public Menu(Dictionary<string, IEnumerable<MenuItem>> menuItems)
        {
            _menuItems = menuItems;
        }


        public IEnumerable<MenuItem> GetMenuItems(string timeOfDay)
        {
            if (!_menuItems.ContainsKey(timeOfDay))
                return null;
            return _menuItems[timeOfDay];
        }
    }
}