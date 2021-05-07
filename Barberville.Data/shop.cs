using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Data
{
    public class shop
    {
        [Key]
        public int ShopId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ShopName { get; set; }

        [Required]
        public string ShopLocation { get; set; }

     

        public string Services { get; set; }
    }
}
