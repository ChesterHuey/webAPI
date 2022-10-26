
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;
    

namespace WebApi.Services;

public class OrderService
{
    private readonly ContactService _customerService;
    private readonly DeliverymanService _deliverymanService;

    public void OrderDeliverd(Order order) {
        _customerService.SendDeliverdNotifcation(order);
        _deliverymanService.PayForDelivery(order);
    }

    public OrderService(CustomerService customerService, DeliverymanService deliverymanService) {
        _customerService = customerService;
        _deliverymanService = deliverymanService;
    }
}

new OrderService(new CustomerService(), new DeliverymanService());
new OrderService(new CustomerService(new NotificationService(),new Database()), new DeliverymanService(new Database()));


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

}
public OrderController(CustoemrService customerService, OrderDervice orderDervice) 
{
    _customerService = customerService;
    _orderService = orderService;
}