using RobotRestaurant.Enums;

namespace RobotRestaurant.Models;

public class Order
{
    public int OrderNumber { get; }
    public Dish OrderedDish { get; }

    public Order(int orderNumber, Dish orderedDish)
    {
        OrderNumber = orderNumber;
        OrderedDish = orderedDish;
    }
}