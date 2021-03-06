namespace DTOs
{
    public class ProductDTO : BaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }

        public string Description { get; set; }
    }
}
