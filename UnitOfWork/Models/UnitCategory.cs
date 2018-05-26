using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Models
{
    public class UnitCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UnitProduct> Products { get; set; }
    }
}
