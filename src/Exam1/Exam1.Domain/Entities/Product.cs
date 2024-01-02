using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Entities
{ 
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public double Weight { get; set; }
    }
}
