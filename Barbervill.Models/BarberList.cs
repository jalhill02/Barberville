using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class BarberList
    {
        public int BarberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public string Services { get; set; }

        //[Required]
        // public int ShopId { get; set; }

        [Required]
        public string ShopName { get; set; }

        [Required]
        public string ShopLocation { get; set; }
       //  public string Menu { get; set; }
    }
}
