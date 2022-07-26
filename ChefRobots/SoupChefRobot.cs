using RobotRestaurant.Enums;
using RobotRestaurant.Models;

namespace RobotRestaurant.ChefRobots;

public class SoupChefRobot : ChefRobot
{
    public SoupChefRobot(int id) : base(id)
    {
    }

    public override bool CanPrepare(Order order)
    {
        return !IsBusy & order.OrderedDish == Dish.Soup;
    }
}