namespace Customers.DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength ( 100 )]
        public string Name { get; set; }
        [MaxLength ( 100 )]
        public string Email { get; set; }
        [MaxLength ( 20 )]
        public string Phone { get; set; }
    }
}
