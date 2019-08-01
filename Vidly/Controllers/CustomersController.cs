using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        public ActionResult New()
        {
            
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else {
                var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerinDb.Name = customer.Name;
                customerinDb.BirthDate = customer.BirthDate;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewModel);
        }


        public ActionResult Index() {
          //  var customers = _context.Customers.Include(c => c.membershipType ).ToList();         
            return View();
        }
        

        public ActionResult Details(int? Id)
        {
            var customer = _context.Customers.Include(c => c.membershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        //public IEnumerable<Customer> GetCustomers() {
        //    return new List<Customer> {
        //          new Customer{ Name="Customer1", Id=1},
        //         new Customer { Name="Customer2", Id=2 }
        //    };
        //}
       
    }
}