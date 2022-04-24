namespace CustomersAPI
{
    using AutoMapper;
    using Customers.DAL.Models;
    using CustomersAPI.Dtos;

    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles ( )
        {
            CreateMap<Customer, CustomerDto> ().ReverseMap();
        }
    }
}
