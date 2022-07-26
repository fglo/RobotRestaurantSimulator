using RobotRestaurant.Enums;

namespace RobotRestaurant.Ui;

public class UiService : IUiService
{
    private static int _orders;

    public UiInput GetInput()
    {
        if (_orders >= 64) return UiInput.CloseRestaurant;
        _orders++;
        return UiInput.NewOrder;
    }

    public Dish GetDish()
    {
        var values = Enum.GetValues(typeof(Dish));
        var random = new Random();
        return (Dish) values.GetValue(random.Next(values.Length))!;
    }
}