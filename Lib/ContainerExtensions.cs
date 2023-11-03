using Autofac;
using Photoshop;

namespace Lib;

public static class ContainerExtensions
{
    public static void UseLib(this ContainerBuilder builder)
    {
        builder.RegisterType<ManagedEnumService>().As<IService<ManagedEnum>>();
        builder.RegisterType<BlendModeService>().As<IService<PsBlendMode>>();
    }
}