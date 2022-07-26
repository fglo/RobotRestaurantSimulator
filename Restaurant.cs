using RobotRestaurant.Dispatchers;
using RobotRestaurant.Enums;
using RobotRestaurant.Ui;

namespace RobotRestaurant;

public class Restaurant
{
    private bool _isOpen = true;

    private readonly IUiService _ui;
    private readonly Dispatcher _dispatcher;
    
    public Restaurant(IUiService ui)
    {
        _ui = ui;
        _dispatcher = new Dispatcher(2);
    }
    
    public void Open()
    {
        _isOpen = true;
        Console.WriteLine("[Restaurant] Opened");
        while (_isOpen)
        {
            // Get input from the user about which action to perform. 
            var uiInput = _ui.GetInput();

            // Execute the action 
            switch (uiInput)
            {
                case UiInput.NewOrder:
                    var orderedDish = _ui.GetDish();
                    _dispatcher.NewOrder(orderedDish);
                    break;
                case UiInput.CloseRestaurant:
                    this.Close();
                    break;
            }

            Task.Delay(100).Wait();
        }
        
        Console.WriteLine("[Restaurant] Closed");
    }

    private void Close()
    {
        _isOpen = false;
        Console.WriteLine("[Restaurant] Closing...");
        _dispatcher.Stop();
    }
}