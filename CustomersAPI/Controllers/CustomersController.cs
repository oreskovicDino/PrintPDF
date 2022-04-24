// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersAPI.Controllers
{
    using AutoMapper;
    using Customers.DAL.DataAccess;
    using Customers.DAL.Models;
    using CustomersAPI.Dtos;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route ( "api/[controller]" )]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomersController ( ICustomerRepository customerRepository, IMapper mapper )
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> Get ( )
        {
            var customers = await customerRepository.GetCustomers ( );

            if ( customers.ToList ( ).Count < 0 )
            {
                return NotFound ( );
            }

            return Ok ( customers );
        }

        // GET api/<CustomersController>/5
        [HttpGet ( "{id}" )]
        public async Task<IActionResult> Get ( int id )
        {
            var customer = await customerRepository.GetCustomerById ( id );

            if ( customer is null )
            {
                return NotFound ( );
            }

            return Ok ( customer );
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post ( [FromBody] CustomerDto customer )
        {
            customerRepository.AddCustomer ( mapper.Map<Customer> ( customer ) );
        }

        // PUT api/<CustomersController>/5
        [HttpPut ( "{id}" )]
        public void Put ( int id, [FromBody] string value )
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete ( "{id}" )]
        public void Delete ( int id )
        {
        }
    }
}
