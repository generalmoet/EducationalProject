using AutoMapper;
using System.Reflection;

namespace Application.Mapping;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assebmly)
    {
        ApplyMappingFromAssembly(assebmly);
    }

    private void ApplyMappingFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMap<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
