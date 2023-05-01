using Domain.CustomFields;
using Domain.Dtos.CustomFeildDtos;
using Domain.Dtos.Product.CreateProductDtos;

namespace Domain.Services
{
    public interface ICustomFeildService : IGenaricSerivce<CustomField, CustomFieldDto, CreateCustomFieldDto, UpdateCustomFieldDto>
    {
        Task CreateAndUpdateCustomFiledWithKeyes(List<CreateCustomFeild> createCustomFeilds);
    }
}
