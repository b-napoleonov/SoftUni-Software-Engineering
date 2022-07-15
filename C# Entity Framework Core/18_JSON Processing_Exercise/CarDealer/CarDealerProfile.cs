using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDTO, Supplier>();
            this.CreateMap<PartDTO, Part>();
            this.CreateMap<CarDTO, Car>();
            this.CreateMap<CustomerDTO, Customer>();
            this.CreateMap<SaleDTO, Sale>();
        }
    }
}
