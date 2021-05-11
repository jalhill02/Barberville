using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
   public class BarberEdit
    {
        public int BarberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopLocation { get; set; }
        public string Services { get; set; }


    }
}
