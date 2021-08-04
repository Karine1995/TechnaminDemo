using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public class UpdateProductInput
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }

        public string Description { get; set; }
    }
}
