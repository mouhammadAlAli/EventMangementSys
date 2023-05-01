namespace Domain.Dtos.Product.CreateProductDtos
{
    public class CreateProductDto
    {
        public Guid CategoryId { get; set; }
        public DateTime StartAppearingDate { get; set; }
        public int DurationInDays { get; set; }
        public double Price { get; set; }
        public List<CreateProductTranslationDto> CreateProductTranslationDto { get; set; }
        public List<CreateCustomFeild> CustomFeilds { get; set; }
    }
}
