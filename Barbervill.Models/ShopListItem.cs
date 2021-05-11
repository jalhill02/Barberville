using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class ShopListItem
    {[Key]
        public int ShopId { get; set; }
        //public string FullName { get; set; }

        //[Display(Name = "Created")]
        //public DateTimeOffset CreatedUtc { get; set; }
       

        
        public string ShopName { get; set; }

      
        public string ShopLocation { get; set; }
        //public string Menu { get; set; }
    }
}
