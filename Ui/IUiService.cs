using RobotRestaurant.Enums;

namespace RobotRestaurant.Ui;

public interface IUiService
{
    UiInput GetInput();
    Dish GetDish();
}