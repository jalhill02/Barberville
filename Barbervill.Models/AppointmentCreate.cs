using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class AppointmentCreate
    {
        //[Key]
        //public int AppointmentId { get; set; }
        [Required]
        public string CustomerName { get; set; }

        public int BarberId { get; set; }

        public int ShopId { get; set; }

        public int CustomerId { get; set; }

        public DateTime Time { get; set; }

        public string PhoneNumber { get; set; }

        //[MaxLength(50)]
        //public string Content { get; set; }
    }
}
