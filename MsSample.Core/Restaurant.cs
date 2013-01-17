using System;
using System.ComponentModel.DataAnnotations;

namespace MsSample.Core
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        public string Address { get; set; }

        public string WebsiteUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}
