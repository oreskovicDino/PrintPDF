namespace Customers.DAL.DataAccess
{
    using Customers.DAL.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerRepository
    {
        Task<bool> AddCustomer ( Customer customer );
        Task<Customer> GetCustomerById ( int id );
        Task<IEnumerable<Customer>> GetCustomers ( );
        void RemoveCustomer ( Customer customer );
    }
}