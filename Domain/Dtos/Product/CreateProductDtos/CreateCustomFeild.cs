namespace Domain.Dtos.Product.CreateProductDtos
{
    public class CreateCustomFeild
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public List<CreateProductCustomFeildKeyesAndValue> Values { get; set; }
    }
}
