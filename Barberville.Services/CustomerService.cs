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

                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ShopName = model.ShopName,
                    ShopLocation = model.ShopAddress

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
                                    FullName = e.FullName,
                                    ShopName = e.ShopLocation
                                }
                        );

                return query.ToArray();
            }
        }

        public BarberDetails GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Barbers.Single(e => e.BarberId == id && e.OwnerId == _userId);

                return new BarberDetails
                {
                    BarberId = entity.BarberId,
                    FullName = entity.FullName,
                    ShopName = entity.ShopName,
                    ShopLocation = entity.ShopLocation,

                };
            }
        }

        public bool EditBarber(BarberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Barbers.Single(e => e.BarberId == model.BarberId && e.OwnerId == _userId);

                entity.BarberId = model.BarberId;
                entity.ShopName = model.ShopName;
                entity.ShopLocation = model.ShopLocation;
                return ctx.SaveChanges() == 1;


            };
        }

        public bool DeleteBarber(int barberId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Barbers
                        .Single(e => e.BarberId == barberId && e.OwnerId == _userId);

                ctx.Barbers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
