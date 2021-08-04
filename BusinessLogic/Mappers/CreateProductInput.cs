using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class CreateProductInput
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public bool Available { get; set; }

        public string Description { get; set; }
    }
}
