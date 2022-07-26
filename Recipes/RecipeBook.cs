using RobotRestaurant.Enums;

namespace RobotRestaurant.Recipes;

public static class RecipeBook
{
    private static readonly Dictionary<Dish, Recipe> Recipes = new()
    {
        {Dish.Soup, new Recipe {CookingTime = 1000}},
        {Dish.Porkchop, new Recipe {CookingTime = 600}},
        {Dish.ScrambledEggs, new Recipe {CookingTime = 200}}
    };

    public static Recipe GetRecipe(Dish dish)
    {
        return Recipes[dish];
    }
}