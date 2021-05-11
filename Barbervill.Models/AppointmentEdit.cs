using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class AppointmentEdit
    {
        public int AppointmentId { get; set; }

        //public DateTime dateTime { get; set; }

        //public int ShopId { get; set; }
       
        public string Services { get; set; }

        //public int CustomerId { get; set; }
        //public int BarberId { get; set; }

        [Display(Name = "Appointment Time")]
        public DateTime DateTime { get; set; }

    }
}
