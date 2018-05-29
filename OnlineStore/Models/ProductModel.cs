using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Range(0, 100000)]
        public double Price { get; set; }
        public string Photo { get; set; }
        [Required]
        [Range(0, 1000)]
        public int Amount { get; set; }
    }
}
