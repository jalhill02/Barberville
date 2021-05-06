using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class CustomerEdit
    {
        public int BarberId { get; set; }
        public string FullName { get; set; }
        public string Content { get; set; }

        public string ShopName { get; set; }


        public string ShopLocation { get; set; }
        public string services { get; set; }

    }
}
