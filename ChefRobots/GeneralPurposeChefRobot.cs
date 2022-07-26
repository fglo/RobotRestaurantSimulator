using RobotRestaurant.Models;
using RobotRestaurant.Recipes;

namespace RobotRestaurant.ChefRobots;

public class GeneralPurposeChefRobot : ChefRobot
{
    public GeneralPurposeChefRobot(int id) : base(id)
    {
    }

    public async Task PrepareOrder(Order order)
    {
        IsBusy = true;

        Console.WriteLine($"[ChefRobot #{_id}] Received order #{order.OrderNumber}: {order.OrderedDish}");

        await ExecuteRecipe(RecipeBook.GetRecipe(order.OrderedDish));

        Console.WriteLine($"[ChefRobot #{_id}] Finished order #{order.OrderNumber}: {order.OrderedDish}");

        IsBusy = false;
    }
}