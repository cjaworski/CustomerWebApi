using System.Collections.Generic;
using System.Linq;
using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return _context.Customers.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public ActionResult<Customer> GetById(long id)
        {
            var item = _context.Customers.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomer", new { id = item.Id }, item);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Customer item)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = item.Name;
            customer.Surname = item.Surname;
            customer.PhoneNumber = item.PhoneNumber;
            customer.Address = item.Address;

            _context.Customers.Update(customer);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Customers.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
