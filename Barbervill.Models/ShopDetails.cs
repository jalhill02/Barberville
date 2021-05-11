using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class ShopDetails
    {
        public int ShopId { get; set; }
        public string ShopLocation { get; set; }
        public string Services { get; set; }  // Needs to be menu class
        public string ShopName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string BarberName { get; set; }

    }
}
