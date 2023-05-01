namespace Domain.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public DateTime StartAppearingDate { get; set; }
        public int DurationInDays { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public List<CustomFiledProductDto> CustomFileds { get; set; }
    }
}
