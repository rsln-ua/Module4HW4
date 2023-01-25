using AutoMapper;
using Module4HW4.Data.Entities;
using Module4HW4.Models;

namespace Module4HW4.Profiles;

public class ModelsToEntities : Profile
{
    public ModelsToEntities()
    {
        CreateMap<Category, CategoryEntity>();
        CreateMap<Customer, CustomerEntity>();
        CreateMap<Order, OrderEntity>();
        CreateMap<OrderDetails, OrderDetailsEntity>();
        CreateMap<Payment, PaymentEntity>();
        CreateMap<Product, ProductEntity>();
        CreateMap<Shipper, ShipperEntity>();
        CreateMap<Supplier, SupplierEntity>();
    }
}