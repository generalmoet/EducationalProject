using AutoMapper;

namespace Application.Mapping;

public interface IMap<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
