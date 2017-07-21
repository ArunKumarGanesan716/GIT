namespace FoodScheduler.Common
{
    public  class MenuItem
    {
        readonly DishType _dishType;
        readonly Dish _dish;
        readonly int _allowedItems;

        public MenuItem(DishType dishType, Dish dish, int allowedItems = 1)
        {
            _dishType = dishType;
            _dish = dish;
            _allowedItems = allowedItems;
        }

        public Dish Dish
        {
            get { return _dish; }
        }

        public int AllowedItems
        {
            get { return _allowedItems; }
        }

        public DishType DishType
        {
            get { return _dishType; }
        }
    }
}