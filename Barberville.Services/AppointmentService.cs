using Barbervill.Models;
using Barberville.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Services
{
    public class AppointmentService
    {
        private readonly Guid _userId;
        public AppointmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity =
                new Appointment()
                {

                    Time = model.Time,
                    BarberId = model.BarberId,
                    ShopId = model.ShopId,
                    CustomerId = model.CustomerId

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Appointments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AppointmentItemList> GetAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Appointments
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AppointmentItemList
                                {
                                    Time = e.Time,
                                    CustomerName = e.Customer.FullName,
                                    ShopLocation = e.Shop.ShopLocation
                                }
                        );

                return query.ToArray();
            }
        }

        public BarberDetails GetAppointmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Barbers.Single(e => e.BarberId == id && e.OwnerId == _userId);

                return new BarberDetails
                {
                    BarberId = entity.BarberId,
                    FullName = entity.FullName,
                   // ShopName = entity.Shop.ShopName,
                    //ShopLocation = entity.Shop.ShopLocation,

                };
            }
        }

        public bool EditAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Appointments.Single(e => e.AppointmentId == model.AppointmentId && e.OwnerId == _userId);

                entity.AppointmentId = model.AppointmentId;
                entity.Time = model.DateTime;
                entity.BarberId = model.BarberId;
                return ctx.SaveChanges() == 1;


            };
        }

        public bool DeleteAppointment(int appointmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appointments
                        .Single(e => e.AppointmentId == appointmentId && e.OwnerId == _userId);

                ctx.Appointments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
