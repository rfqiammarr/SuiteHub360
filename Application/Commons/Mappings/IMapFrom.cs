using AutoMapper;

namespace RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;

public interface IMapFrom<TSource, TDestination>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TSource, TDestination>();
    }
}
