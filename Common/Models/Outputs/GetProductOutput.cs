using System;

namespace Common.Models.Outputs
{
    public class GetProductOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
