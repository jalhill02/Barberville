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

        [Required]
        [MinLength(2, ErrorMessage = "The store name must be at least 2 Characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in thes field")]
        public string shopName { get; set; }

        [MaxLength(10000)]
        public string service { get; set; }

        public string Location { get; set; }

        public DateTime CreatedUtc { get; set; }

        public int ServiceId { get; set; }
    }
}
