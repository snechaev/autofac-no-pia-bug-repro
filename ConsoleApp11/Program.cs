
using Autofac;
using Lib;
using Photoshop;

var myType = typeof(PsBlendMode); //type, embedded into the current assembly
//var libType = LibClassProvider.PsBlendModeType; //the same type, embedded into the Lib assembly
var libType = typeof(IService<>).Assembly.GetType(typeof(PsBlendMode).FullName!)!;

Console.WriteLine($"Types: {myType.AssemblyQualifiedName} and {libType.AssemblyQualifiedName}");
Console.WriteLine($"Types equals (operator ==): {myType == libType}");
Console.WriteLine($"Types IsEquivalentTo: {myType.IsEquivalentTo(libType)}");

var builder = new ContainerBuilder();
builder.UseLib();
var container = builder.Build();

var genericListType = typeof(IService<>).MakeGenericType(libType);


var canResolveManagedEnum = container.TryResolve(typeof(IService<ManagedEnum>), out _); //ok
var canResolveLibEnum = container.TryResolve(genericListType, out _); //ok
var canResolveCurrentAssemblyEnum = container.TryResolve(typeof(IService<PsBlendMode>), out _); //fail

Console.WriteLine($"Trying to resolve managed enum, declared in the Lib assembly: {canResolveManagedEnum}");
Console.WriteLine($"Trying to resolve embedded enum, declared in the Lib assembly:  {canResolveLibEnum}");
Console.WriteLine($"Trying to resolve  embedded enum, declared in the ConsoleApp11 assembly:  {canResolveCurrentAssemblyEnum}");


System.Diagnostics.Debug.Assert(canResolveManagedEnum, "Failed to resolve managed enum, declared in the Lib assembly");
System.Diagnostics.Debug.Assert(canResolveLibEnum, "Failed to resolve embedded enum, declared in the Lib assembly");
System.Diagnostics.Debug.Assert(canResolveCurrentAssemblyEnum, "Failed to resolve  embedded enum, declared in the ConsoleApp11 assembly");
