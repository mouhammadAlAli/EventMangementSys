#nullable disable
using AutoMapper;
using Domain.CustomFields;
using Domain.Dtos.CustomFeildDtos;
using Domain.Dtos.Product.CreateProductDtos;
using Domain.Exceptions;
using Domain.Repositries;
using Domain.Services;

namespace Application.Services
{
    internal class CustomFeildService : GenaricSerivce<CustomField, CustomFieldDto, CreateCustomFieldDto, UpdateCustomFieldDto>, ICustomFeildService
    {
        private readonly IRepository<CustomFieldKey> _customFieldKeyRepository;
        public CustomFeildService(IRepository<CustomField> repository, IMapper mapper, IRepository<CustomFieldKey> customFieldKeyRepository) : base(repository, mapper)
        {
            _customFieldKeyRepository = customFieldKeyRepository;
        }
        public async Task CreateAndUpdateCustomFiledWithKeyes(List<CreateCustomFeild> createCustomFeilds)
        {
            var existsCustomFeilds = createCustomFeilds.Where(c => c.Id != null).ToList();
            var nonExistsCustomFeilds = createCustomFeilds.Where(c => c.Id == null).ToList();
            //if there is any  key have id with new custome filed should be throw exception
            var fa = nonExistsCustomFeilds.SelectMany(c => c.Values).Where(c => c.KeyId != null);
            if (fa.Any())
            {
                throw new DomainException("msg");
            }
            var fields = await GetAll(c => existsCustomFeilds.Select(c => c.Id.Value).Contains(c.Id));
            if (fields.Count() != existsCustomFeilds.Count)
            {
                //TODO:get Id
                throw new NotFoundException(nameof(CustomField), "");
            }
            var exisitngCustomFiledsNeedToAddKeyes = existsCustomFeilds.Where(c => c.Values.Any(v => v.KeyId == null)).ToList();
            await AddKeyRange(exisitngCustomFiledsNeedToAddKeyes);
            await CreateRange(nonExistsCustomFeilds);
        }
        private  async Task CreateRange(List<CreateCustomFeild> createCustomFeilds)
        {
            createCustomFeilds.ForEach(c =>
            {
                c.Id = Guid.NewGuid();
                c.Values.ForEach(v =>
                {
                    v.KeyId = Guid.NewGuid();
                });
            });
            var data = createCustomFeilds.Select(c => new CustomField()
            {
                Id = c.Id.Value,
                Name = c.Name,
                CreatedOnUtc = DateTime.UtcNow,
                CreatedBy = "System",
                CustomFieldKeys = c.Values.Select(c => new CustomFieldKey()
                {
                    Id = c.KeyId.Value,
                    Key = c.Key
                }).ToList()
            });
            await _repository.CreateRange(data);
        }
        private async Task AddKeyRange(IEnumerable<CreateCustomFeild> createCustomFeilds)
        {
            var newKeyes = createCustomFeilds.SelectMany(c => c.Values).Where(c => c.KeyId == null).ToList();
            newKeyes.ForEach(c =>
            {
                c.KeyId = Guid.NewGuid();
            });

            var ids = createCustomFeilds.Select(c => c.Id);
            var customKeyesList = new List<CustomFieldKey>();

            foreach (var item in ids)
            {
                var dto = createCustomFeilds.First(c => c.Id == item);
                var newValues = dto.Values.Where(c => c.KeyId == null).ToList();
                newKeyes.ForEach(c =>
                {
                    c.KeyId = Guid.NewGuid();
                });
                customKeyesList.AddRange(newKeyes.Select(c => new CustomFieldKey()
                {
                    Key = c.Key,
                    Id = c.KeyId.Value,
                    CustomFieldId = item.Value
                }));

            }
            await _customFieldKeyRepository.CreateRange(customKeyesList);
        }
    }
}
