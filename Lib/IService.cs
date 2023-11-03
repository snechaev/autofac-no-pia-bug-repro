using Photoshop;

namespace Lib;

public interface IService<T>{}

public class BlendModeService : IService<PsBlendMode>
{
}

public class ManagedEnumService : IService<ManagedEnum>
{
}