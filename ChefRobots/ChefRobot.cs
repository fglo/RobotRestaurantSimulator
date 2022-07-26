using RobotRestaurant.Dispatchers;
using RobotRestaurant.Models;
using RobotRestaurant.Recipes;

namespace RobotRestaurant.ChefRobots;

public abstract class ChefRobot : IChefRobot
{
    protected readonly int _id;
    public bool IsBusy { get; protected set; }

    protected ChefRobot(int id)
    {
        _id = id;
    }

    public virtual async Task PrepareOrder(Order order)
    {
        IsBusy = true;

        Console.WriteLine($"[ChefRobot #{_id}] Received order #{order.OrderNumber}: {order.OrderedDish}");

        await ExecuteRecipe(RecipeBook.GetRecipe(order.OrderedDish));

        Console.WriteLine($"[ChefRobot #{_id}] Finished order #{order.OrderNumber}: {order.OrderedDish}");

        IsBusy = false;
    }

    public virtual async Task ExecuteRecipe(Recipe recipe)
    {
        await Task.Delay(recipe.CookingTime);
    }

    public virtual bool CanPrepare(Order order)
    {
        return !IsBusy;
    }
}