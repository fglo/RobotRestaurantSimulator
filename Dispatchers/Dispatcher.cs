using RobotRestaurant.ChefRobots;
using RobotRestaurant.Enums;
using RobotRestaurant.Models;

namespace RobotRestaurant.Dispatchers;

public class Dispatcher
{
    private readonly List<IChefRobot> _chefRobots;
    private readonly Queue<Order> _orders;

    private int _lastOrderNumber;

    private bool _running;
    private Task? _process;

    public Dispatcher(int robotsCount)
    {
        _chefRobots = new List<IChefRobot>();
        _orders = new Queue<Order>();
        _lastOrderNumber = 0;
        for (var i = 0; i < robotsCount; i++)
        {
            _chefRobots.Add(new GeneralPurposeChefRobot(i + 1));
        }
        _chefRobots.Add(new SoupChefRobot(robotsCount + 1));
    }

    // this method should be non-blocking - should end immediately and the order should be processed in the background
    public void NewOrder(Dish orderedDish)
    {
        Console.WriteLine($"[Dispatcher] New order: {orderedDish}");
        _orders.Enqueue(new Order(++_lastOrderNumber, orderedDish));

        if (!_running)
        {
            _process = Task.Run(ProcessOrders);
        }
    }

    private void ProcessOrders()
    {
        Console.WriteLine("[Dispatcher] Starting processing orders");
        _running = true;
        while (_running || _orders.Any())
        {
            if (!_orders.Any()) continue;
            var order = _orders.Peek();
            var freeChef = _chefRobots.FirstOrDefault(_ => _.CanPrepare(order));
            freeChef?.PrepareOrder(_orders.Dequeue());
        }
        Console.WriteLine("[Dispatcher] Finished processing orders");
    }

    public void AskForOrder(IChefRobot chefRobot)
    {
        var order = _orders.FirstOrDefault(chefRobot.CanPrepare);
        if (order != null)
        {
            chefRobot.PrepareOrder(order);
        }
    }

    // implement waiting for current orders to finish, no new orders should be picked up
    public void Stop()
    {
        _running = false;
        Console.WriteLine("[Dispatcher] Waiting for the chefs to empty orders queue...");
        while (_orders.Any()) ;
        // _process.Wait();
        Console.WriteLine("[Dispatcher] Waiting for the chefs to finish last orders...");
        while (_chefRobots.Any(_ => _.IsBusy)) ;
        Console.WriteLine("[Dispatcher] Finished");
    }
}