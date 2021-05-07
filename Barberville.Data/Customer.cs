using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barberville.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(shop))]
        public int ShopId { get; set; }

        [ForeignKey(nameof(Barber))]
        public int FullName { get; set; }
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


        [Required]
        public string ShopName { get; set; }

        [Required]
        public string ShopLocation { get; set; }
        public string Menu { get; set; }



    }
}
