namespace Common.Models.Inputs.Products
{
    public class CreateProductInput
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public bool Available { get; set; }

        public string Description { get; set; }
    }
}
