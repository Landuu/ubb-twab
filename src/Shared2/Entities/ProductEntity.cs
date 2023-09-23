using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class ProductEntity : IEntity
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required decimal Price { get; set; }
    }
}
