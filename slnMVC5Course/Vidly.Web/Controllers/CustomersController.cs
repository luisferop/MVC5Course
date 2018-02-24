using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Web.Models;
using Vidly.Web.ViewModels;

namespace Vidly.Web.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
        [Route("Customers/Details/{id:int}")]
        public ActionResult Details(int id)
        {
            Customer customer = GetCustomers().Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return _context.Customer.Include("MembershipType");
        }
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            CustomerFormViewModel viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipTypes.ToList();
                CustomerFormViewModel viewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = membershipTypes,
                    Customer = model.Customer

                };
                return View("CustomerForm", viewModel);
            }
            if (model.Customer.Id.Equals(0))
            {
                _context.Customer.Add(model.Customer);
            }
            else
            {
                Customer customerInDB = GetCustomers().Where(x => x.Id.Equals(model.Customer.Id)).Single();
                customerInDB.IsSubscribedToNewsLetter = model.Customer.IsSubscribedToNewsLetter;
                customerInDB.MembershipTypeId = model.Customer.MembershipTypeId;
                customerInDB.Name = model.Customer.Name;
                customerInDB.BirthDate = model.Customer.BirthDate;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            Customer customer = GetCustomers().Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            var membershipTypes = _context.MembershipTypes.ToList();
            CustomerFormViewModel viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = customer
            };
            return View("CustomerForm",viewModel);
        }
    }
}