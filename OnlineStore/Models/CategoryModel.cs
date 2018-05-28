using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
