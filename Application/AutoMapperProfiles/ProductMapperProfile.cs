using AutoMapper;
using AutoMapper.Execution;
using Domain.CustomFields;
using Domain.Dtos.CustomFeildDtos;
using Domain.Dtos.Product;
using Domain.Dtos.Product.CreateProductDtos;
using Domain.Products;
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;

namespace Application.AutoMapperProfiles
{
    internal class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Translations, opt => opt.MapFrom((src, dest, i, context) =>
                {
                    return context.Mapper.Map<IEnumerable<ProductTranslation>>(src.CreateProductTranslationDto);
                }))
                .ForMember(dest => dest.CustomFieldValues, opt => opt.MapFrom((src, dest, i, context) =>
                {

                    return context.Mapper.Map<IEnumerable<CustomFieldValue>>(src.CustomFeilds.SelectMany(c => c.Values));
                }));
            CreateMap<CreateProductCustomFeildKeyesAndValue, CustomFieldValue>()
                .ForMember(c => c.CustomFieldKeyId, opt => opt.MapFrom(src => src.KeyId.Value))
                .ForMember(c => c.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<CustomFeildValueDto, CustomFieldValue>()
                .ForMember(dest => dest.CustomFieldKeyId, opt => opt.MapFrom(src => src.KeyId));
            CreateMap<Product, ProductDto>()
                .ForMember(c => c.Name, opt => opt.MapFrom<ProductNameResolver>())
                .ForMember(c => c.CustomFileds, opt => opt.MapFrom((src, dest, i, context) =>
                {
                    var data = new List<CustomFiledProductDto>();
                    var group = src.CustomFieldValues.GroupBy(c => c.CustomFieldKey.CustomFieldId);
                    foreach (var item in group)
                    {
                        var list = item.ToList();
                        var name = list.First().CustomFieldKey.CustomField.Name;
                        data.Add(new CustomFiledProductDto()
                        {
                            Id = item.Key,
                            Name = name,
                            Values = context.Mapper.Map<List<CustomFiledKeyValuePair>>(list)
                        });
                    }

                    return data;
                }));
            CreateMap<CustomFieldValue, CustomFiledKeyValuePair>()
                .ForMember(c => c.KeyId, opt => opt.MapFrom(src => src.CustomFieldKeyId))
                .ForMember(c => c.Key, opt => opt.MapFrom(src => src.CustomFieldKey.Key))
                .ForMember(c => c.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<CustomField, CustomFieldDto>();
            CreateMap<CreateProductTranslationDto, ProductTranslation>();
            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.Translations, opt => opt.MapFrom((src, dest, i, context) =>
            {
                var data = context.Mapper.Map<IEnumerable<ProductTranslation>>(src.CreateProductTranslationDto).ToList() ;
                data.ForEach(c => c.CoreId = src.Id);
                return data;
            }))
                .ForMember(dest => dest.CustomFieldValues, opt => opt.MapFrom((src, dest, i, context) =>
                {
                    var data = context.Mapper.Map<IEnumerable<CustomFieldValue>>(src.CustomFeilds.SelectMany(c => c.Values)).ToList();
                    data.ForEach(c=>c.ProducId=src.Id);
                    return data;
                }));
        }
        internal class ProductNameResolver : IValueResolver<Product, ProductDto, string>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public ProductNameResolver(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
            {
                var header = _httpContextAccessor.HttpContext.Request.Headers;
                if (header.ContainsKey("Accept-Language"))
                {
                    var lang = header["Accept-Language"];
                    return source.Translations?.FirstOrDefault(c => c.Language == lang)?.Name ?? "";
                }
                return source.Translations?.FirstOrDefault()?.Name ?? "";
            }
        }
    }
}
