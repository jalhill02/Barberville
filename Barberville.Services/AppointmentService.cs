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
                    OwnerId = _userId,
                    // AppointmentId = model.AppointmentId,
                    BarberId = model.BarberId,
                    ShopId = model.ShopId,
                    CustomerId = model.CustomerId,
                    Time = model.Time,
                    Service = "",
                    CreatedUtc = DateTimeOffset.Now,
                    PhoneNumber = model.PhoneNumber
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
                                    AppointmentId = e.AppointmentId,
                                    FirstName = e.Customer.FirstName,
                                    LastName = e.Customer.LastName,
                                    PhoneNumber = e.Customer.PhoneNumber,
                                    ShopLocation = e.Shop.ShopLocation,
                                    BarberName = e.Barber.FirstName
                                }
                        );

                return query.ToArray();
            }
        }

        public AppointmentDetails GetAppointmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Appointments.Single(e => e.AppointmentId == id && e.OwnerId == _userId);

                return new AppointmentDetails
                {
                    AppointmentId = entity.AppointmentId,
                    BarberName = entity.Barber.FirstName,
                    ShopLocation = entity.Shop.ShopLocation,
                    ShopName = entity.Shop.ShopName,
                    DateTime = entity.Time,
                    services = entity.Service

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
                entity.Service = model.Services;
                // entity.BarberId = model.BarberId;
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
