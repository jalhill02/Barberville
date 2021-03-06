using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class AppointmentDetails
    {
        public int AppointmentId { get; set; }
        public string BarberName { get; set; }
        public string ShopName { get; set; }

        public string ShopLocation { get; set; }
        public string services { get; set; }


        [Display(Name = "Appointment Time")]
        public DateTime DateTime { get; set; }
      
    }
}
