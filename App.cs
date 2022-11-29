using Module4HW4.Models;
using Module4HW4.Services.Abstractions;

namespace Module4HW4;

public class App
{
    private ICategoryService _categoryService;
    private ICustomerService _customerService;
    private IOrderService _orderService;
    private IOrderDetailsService _orderDetailsService;
    private IPaymentService _paymentService;
    private IProductService _productService;
    private IShipperService _shipperService;
    private ISupplierService _supplierService;

    public App(
        ICategoryService categoryService,
        ICustomerService customerService,
        IOrderService orderService,
        IOrderDetailsService orderDetailsService,
        IPaymentService paymentService,
        IProductService productService,
        IShipperService shipperService,
        ISupplierService supplierService)
    {
        _categoryService = categoryService;
        _customerService = customerService;
        _orderService = orderService;
        _orderDetailsService = orderDetailsService;
        _paymentService = paymentService;
        _productService = productService;
        _shipperService = shipperService;
        _supplierService = supplierService;
    }

    public async Task Start()
    {
        var supplierId = await _supplierService.CreateSupplier("OOO Roga i kopyta", "Vasya", "Pupkin", await _customerService.CreateCustomer("Petrushka", "Zeleniy"));
        var shipperId = await _shipperService.CreateShipper("Sharashkina kontora", "103");
        var paymentId = await _paymentService.CreatePayment();
        var customerId = await _customerService.CreateCustomer("John", "Biden");
        var category1Id = await _categoryService.CreateCategory("food", "fuel for people");
        var category2Id = await _categoryService.CreateCategory("gas", "fuel for cars");
        var category3Id = await _categoryService.CreateCategory("drinks", "No alcohol");
        var product1Id =
            await _productService.CreateProduct("borshc", "ocheny vkusno", 100, 0, category1Id, supplierId);
        var product2Id =
            await _productService.CreateProduct("benzin", "vonyuchiy, dorogoy", 100500, 0, category2Id, supplierId);
        var product3Id =
            await _productService.CreateProduct("sosa-sola", "🦾", 40, 0, category3Id, supplierId);
        var orderId = await _orderService.MakeAnOrder(customerId, paymentId, shipperId, new List<OrderDetailsBar>()
        {
            new OrderDetailsBar() { ProductId = product2Id, Quantity = 1 },
            new OrderDetailsBar() { ProductId = product2Id, Quantity = 2 },
            new OrderDetailsBar() { ProductId = product1Id, Quantity = 3 },
            new OrderDetailsBar() { ProductId = product1Id, Quantity = 4 },
            new OrderDetailsBar() { ProductId = product3Id, Quantity = 5 },
            new OrderDetailsBar() { ProductId = product3Id, Quantity = 6 },
        });

        await _categoryService.UpdateCategory(new Category()
            { Id = category2Id, Name = "fuel", Description = "100600" });

        await _categoryService.DeleteCategory(category1Id);
        {
            var customer = await _customerService.GetCustomer(customerId);
            Console.WriteLine("====================================");

            foreach (var el in customer.Orders)
            {
                Console.WriteLine(el.Id);
                Console.WriteLine(el.Customer.FirstName);
            }

            Console.WriteLine("====================================");
        }

        {
            var order = await _orderService.GetFullOrderById(orderId.GetValueOrDefault());
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");

            foreach (var el in order.OrderDetails)
            {
                Console.WriteLine(el.Id);
                Console.WriteLine(el.Product.Name);
            }

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
        }
    }
}