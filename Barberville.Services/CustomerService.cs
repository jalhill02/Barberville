using System;
using Barberville.Data;
using Barbervill.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;
        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                 
                                }
                        );

                return query.ToArray();
            }
        }

        public CustomerDetails GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == id && e.OwnerId == _userId);

                return new CustomerDetails
                {
                    CustomerId = entity.CustomerId,
                    FistName = entity.FirstName,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber
                 

                };
            }
        }

        public bool EditCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.FirstName = model.FistName;
                entity.LastName = model.LastName;
                return ctx.SaveChanges() == 1;


            };
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
