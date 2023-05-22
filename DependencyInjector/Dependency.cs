using DependencyInjector.Providers;

namespace DependencyInjector; 

public static class Dependency {
    private static IDependencyProvider _provider = new DefaultProvider();

    public static T Inject<T>(params object[] args) => _provider.Inject<T>(args);
    public static void Provide<T>(params object[] args) => _provider.Provide<T>(args);
    public static void Provide<TAccessor, TImplementor>(params object[] args) where TImplementor : TAccessor => _provider.Provide<TAccessor, TImplementor>(args);

    public static void UseProvider<T>(params object[] args) where T : IDependencyProvider => _provider = (IDependencyProvider)Activator.CreateInstance(typeof(T), args)!;
}