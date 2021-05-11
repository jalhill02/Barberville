using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class ShopCreate
    {
        public int ShopId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The store name must be at least 2 Characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in thes field")]
        public string ShopName { get; set; }

        public string BarberName { get; set; }

        [MaxLength(10000)]
        public string Services { get; set; }

        public string ShopLocation { get; set; }

        public DateTime CreatedUtc { get; set; }

     
    }
}
