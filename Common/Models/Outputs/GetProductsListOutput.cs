using System;

namespace Common.Models.Outputs
{
    public class GetProductsListOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }
    }
}
