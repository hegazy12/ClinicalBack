using Domain.Models;

namespace ServiceLayer.ServiceOfServices.DTO
{
    public class ServiceDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
    }

    public class ServiceDTO1 : ServiceDTO
    {
        public Guid Id { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static ServiceDTO1 ToServiceDTO1(this Service service)
        {
            return new ServiceDTO1()
            {
                Id = service.Id,
                name = service.name,
                description = service.description,
                price = service.price
            };
        }
    }
}
