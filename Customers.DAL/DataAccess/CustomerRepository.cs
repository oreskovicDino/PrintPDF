namespace Customers.DAL.DataAccess
{
    using Customers.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDataContext context;

        public CustomerRepository ( CustomerDataContext context )
        {
            this.context = context;
        }

        public async Task<bool> AddCustomer ( Customer customer )
        {
            await context.Customers.AddAsync ( customer );
            context.SaveChanges ( );
            return true;
        }

        public async Task<IEnumerable<Customer>> GetCustomers ( )
        {
            return await context.Customers.ToListAsync ( );
            
        }

        public async Task<Customer> GetCustomerById(int id )
        {
            return await context.Customers.FirstOrDefaultAsync ( c => c.Id == id );
        }

        public void RemoveCustomer(Customer customer )
        {
            context.Customers.Remove( customer );
            context.SaveChanges ( );
        }
    }
}
