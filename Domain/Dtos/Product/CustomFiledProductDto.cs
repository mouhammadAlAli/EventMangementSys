namespace Domain.Dtos.Product
{
    public class CustomFiledProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CustomFiledKeyValuePair> Values { get; set; }
    }
    public class CustomFiledKeyValuePair
    {
        public Guid KeyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
