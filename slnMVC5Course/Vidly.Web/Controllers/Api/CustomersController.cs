using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Web.Dtos;
using Vidly.Web.Models;

namespace Vidly.Web.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/Customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomer()
        {
            return _context.Customer.Include("MembershipType").ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        // GET /api/Customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            CustomerDto customer = _context.Customer
                       .Include("MembershipType")
                       .Where(x => x.Id.Equals(id))
                       .Select(Mapper.Map<Customer,CustomerDto>)
                       .FirstOrDefault();
            if (customer == null)
                NotFound();
            return Ok(customer);
        }

        // POST /api/costumers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerDB = Mapper.Map<CustomerDto, Customer>(customer);
            _context.Customer.Add(customerDB);
            _context.SaveChanges();
            customer.Id = customerDB.Id;
            return Created(new Uri($"{Request.RequestUri}/{customer.Id}"),customer);
        }

        // PUT /api/costumers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customer.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customer, customerInDB);

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customer.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            _context.Customer.Remove(customerInDB);
            _context.SaveChanges();

        }
    }
}
