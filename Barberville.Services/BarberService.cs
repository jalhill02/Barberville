using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Services
{
    class BarberService
    {
        private readonly Guid _userId;
        public BarberService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBarber(BarberCreate model)  //Can't add referene to my model
        {
            var entity = new Barber()

            { OwneerId - _userId, //need a better understanding of this statement
            Title = model.Title,
            Content = model.Content,
            CreatedUtc = DateTimeOffset.Now
            }
        }
    }
}
