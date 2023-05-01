using AutoMapper;
using Domain.CustomFields;
using Domain.Dtos.Product;
using Domain.Dtos.Product.CreateProductDtos;
using Domain.Products;
using Domain.Repositries;
using Domain.Services;

namespace Application.Services
{
    internal class ProductService : GenaricSerivce<Product, ProductDto, CreateProductDto, UpdateProductDto>, IProductSerivce
    {
        private readonly IRepository<ProductTranslation> _productTranslationRepository;
        private readonly IRepository<CustomFieldValue> _customFieldValueRepository;
        public ProductService(IRepository<Product> repository, IMapper mapper, IRepository<ProductTranslation> productTranslationRepository, IRepository<CustomFieldValue> customFieldValueRepository) : base(repository, mapper)
        {
            _productTranslationRepository = productTranslationRepository;
            _customFieldValueRepository = customFieldValueRepository;
        }
        public override async Task Update(UpdateProductDto update)
        {
            var product = await _repository.FirstOrDefualt(c => c.Id == update.Id, c => c.Translations, c => c.CustomFieldValues);
            product.Translations.Clear();
            product.CustomFieldValues.Clear();
            _mapper.Map(update, product);
            await _customFieldValueRepository.CreateRange(product.CustomFieldValues);
            await _productTranslationRepository.CreateRange(product.Translations);
            _repository.Update(product);
        }
    }
}
