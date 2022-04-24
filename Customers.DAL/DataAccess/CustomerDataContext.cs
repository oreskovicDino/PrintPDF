namespace Customers.DAL.DataAccess
{
    using Customers.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class CustomerDataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDataContext ( DbContextOptions<CustomerDataContext> options ) : base ( options )
        {

        }
    }
}
