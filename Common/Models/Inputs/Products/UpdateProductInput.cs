namespace Common.Models.Inputs.Products
{
    public class UpdateProductInput
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }

        public string Description { get; set; }

    }
}
