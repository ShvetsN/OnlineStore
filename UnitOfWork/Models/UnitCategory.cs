using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Models
{
    public class UnitCategory : UnitEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UnitProduct> Products { get; set; }
    }
}
