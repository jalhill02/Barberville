using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberville.Data
{
    public class Barber
    {
        [Key]
        public int BarberId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; }

        [ForeignKey(nameof(shop))]
        public int ShopId { get; set; }


        [Required]
        public string ShopName { get; set; }

        [Required]
        public string ShopLocation { get; set; }
        public string Menu { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [ForeignKey(nameof(shop))]
        public int CategoryId { get; set; }

        public virtual shop shop { get; set; }
    }
}
