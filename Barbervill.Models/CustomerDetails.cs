using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class CustomerDetails
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Content { get; set; }

        public string ShopName { get; set; }


        public string ShopLocation { get; set; }
        public string services { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
