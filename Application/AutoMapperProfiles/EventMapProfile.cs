using AutoMapper;
using Domain.Dtos.Event;
using Domain.Events;
using Microsoft.AspNetCore.Http;

namespace Application.AutoMapperProfiles
{
    internal class EventMapProfile:Profile
    {
        public EventMapProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(x => x.EventName, src => src.MapFrom<EventNameResolver>())
                .ForMember(x => x.EventDescription, src => src.MapFrom<EventDescriptionResolver>());
            CreateMap<EventTranslationDto, EventTranslation>();
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
        }
        internal class EventNameResolver : IValueResolver<Event, EventDto, string>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public EventNameResolver(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string Resolve(Event source, EventDto destination, string destMember, ResolutionContext context)
            {
                var header = _httpContextAccessor.HttpContext.Request.Headers;
                if (header.ContainsKey("Accept-Language"))
                {
                    var lang = header["Accept-Language"];
                    return destination.EventName = source.Translations?.FirstOrDefault(c => c.Language == lang)?.EventName ?? "";
                }
                return source.Translations?.FirstOrDefault()?.EventName ?? "";
            }
        }
        internal class EventDescriptionResolver : IValueResolver<Event, EventDto, string>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public EventDescriptionResolver(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string Resolve(Event source, EventDto destination, string destMember, ResolutionContext context)
            {
                var header = _httpContextAccessor.HttpContext.Request.Headers;
                if (header.ContainsKey("Accept-Language"))
                {
                    var lang = header["Accept-Language"];
                    return destination.EventName = source.Translations?.FirstOrDefault(c => c.Language == lang)?.EventDescription ?? "";
                }
                return source.Translations?.FirstOrDefault()?.EventDescription ?? "";
            }
        }
    }
}
