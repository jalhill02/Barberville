using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class CustomerListItem
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        //[Display(Name = "Created")]
        //public DateTimeOffset CreatedUtc { get; set; }
        //[Required]
        //public int ShopId { get; set; }

        //[Required]
        //public string ShopName { get; set; }

        //[Required]
        //public string ShopLocation { get; set; }
        //public string Menu { get; set; }
    }
}
