using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Data
{
    public class Appointment
    {
        public static int ReminderTime = 30;
        

        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        [Required, Phone, Display(Name ="Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Time { get; set; }


        [Required]
        public string Service { get; set; }
      
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }


        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Shop))]
        public int ShopId { get; set; }

        public virtual shop Shop { get; set; }

        [ForeignKey(nameof(Barber))]
        public int BarberId { get; set; }

        public virtual Barber Barber { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }


    }
}
