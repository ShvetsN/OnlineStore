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
        public double Price { get; set; }
        public string Photo { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
