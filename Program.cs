using Microsoft.Extensions.DependencyInjection;
using RobotRestaurant;
using RobotRestaurant.Ui;

var services = new ServiceCollection();
services.AddTransient<IUiService, UiService>();
services.AddSingleton<Restaurant>();

var serviceProvider = services.BuildServiceProvider();
var restaurant = serviceProvider.GetService<Restaurant>();
restaurant?.Open();
