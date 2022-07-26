using RobotRestaurant.Models;
using RobotRestaurant.Recipes;

namespace RobotRestaurant.ChefRobots;

public interface IChefRobot
{
    bool IsBusy { get; }
    Task PrepareOrder(Order order);
    Task ExecuteRecipe(Recipe recipe);
    bool CanPrepare(Order order);
}