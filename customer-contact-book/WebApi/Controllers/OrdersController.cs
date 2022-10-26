

using Microsoft.AspNetCore.Mvc;

var ServiceCollection = new ServiceCollection();
ServiceCollection.AddScoped<CustomerService>();
ServiceCollection.AddScoped<NotificationService>();
ServiceCollection.AddScoped<OrderService>();

var serviceProvider = ServiceCollection.BuildServiceProvider();
var orderService = serviceProvider.GetRequiredService<OrderService>();

public class OrdersController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly OrderService _orderService;


    public OrderController(CustomerService customerService, OrderService orderService)
    {
        _customerService = customerService;
        _orderService = orderService;
    }
}