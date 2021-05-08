using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbervill.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int ShopId { get; set; }


        public string services { get; set; }

    }
}
