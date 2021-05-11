using System;
using Barberville.Data;
using Barbervill.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Services
{
    public class BarberService
    {
        private readonly Guid _userId;
        public BarberService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBarber(BarberCreate model)
        {
            var entity =
                new Barber()
                {
                    OwnerId = _userId,
                    BarberId = model.BarberId,    //Should I make my userId == barberId/Shopiid/CustomerId?
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ShopName = model.ShopName,
                    Services = model.Services,
                    FullName = model.FullName
                  
             

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Barbers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BarberList> GetBarbers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Barbers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new BarberList
                                {
                                 
                                    BarberId = e.BarberId,    //Should I make my userId == barberId/Shopiid/CustomerId?
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    ShopName = e.ShopName,
                                    Services = e.Services,
                                    FullName = e.FullName
                                }
                        );

                return query.ToArray();
            }
        }
        public BarberDetails GetBarberById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Barbers.Single(e => e.BarberId == id && e.OwnerId == _userId);

                return new BarberDetails
                {

                 
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    ShopName = entity.ShopName,
                    Services = entity.Services,
                   


                };
            }
        }

        public bool EditBarber (BarberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Barbers.Single(e => e.BarberId == model.BarberId && e.OwnerId == _userId);


                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.ShopName = model.ShopName;
                entity.Services = model.Services;
                entity.FullName = model.FullName;
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
