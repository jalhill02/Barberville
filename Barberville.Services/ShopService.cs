using Barbervill.Models;
using Barberville.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Services
{

    public class ShopService
    {
        private readonly Guid _userId;
        public ShopService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShop (ShopCreate model)
        {
            var entity =
                new shop()
                {
                    OwnerId = _userId,
                    ShopId   = model.ShopId,
                    ShopName = model.ShopName,
                    ShopLocation = model.ShopLocation,
                    BarberName = model.BarberName,
                    CreatedUtc = model.CreatedUtc,
                    Services = model.Services
                

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shops.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShopListItem> GetShop()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shops
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ShopListItem
                                {
                                    ShopId = e.ShopId,
                                    ShopName = e.ShopName,
                                    ShopLocation = e.ShopLocation,
                                    BarberName = e.BarberName,
                                    Services = e.Services
                                }
                        );

                return query.ToArray();
            }
        }

        public ShopDetails GetShopById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shops.Single(e => e.ShopId == id && e.OwnerId == _userId);

                return new ShopDetails
                {
                    ShopId = entity.ShopId,
                    ShopName = entity.ShopName,
                    ShopLocation = entity.ShopLocation,
                    BarberName = entity.BarberName,
                    Services = entity.Services


                };
            }
        }

        public bool EditShop (ShopEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Shops.Single(e => e.ShopId == model.ShopId && e.OwnerId == _userId);

               
                entity.ShopName = model.ShopName;
                entity.ShopLocation = model.ShopLocation;
                entity.BarberName = model.BarberName;
                entity.Services = model.Service;
                 


                return ctx.SaveChanges() == 1;


            };
        }

        public bool DeleteShop (int ShopId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shops
                        .Single(e => e.ShopId == ShopId && e.OwnerId == _userId);

                ctx.Shops.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
