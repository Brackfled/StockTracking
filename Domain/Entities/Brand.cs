using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand:Entity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public Brand(Guid id, string name):this()
        {
            Name = name;
        }
    }
}
