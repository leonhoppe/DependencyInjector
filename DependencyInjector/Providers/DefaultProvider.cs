using System.Reflection;

namespace DependencyInjector.Providers; 

internal class DefaultProvider : IDependencyProvider {
    public IDictionary<Type, object> Dependencies { get; } = new Dictionary<Type, object>();

    public T Inject<T>(params object[] args) {
        var type = typeof(T);
        if (Dependencies.ContainsKey(type))
            return (T)Dependencies[type];

        return Provide<T>(args);
    }

    public T Provide<T>(params object[] args) {
        return Provide<T, T>(args);
    }

    public TAccessor Provide<TAccessor, TImplementor>(params object[] args) where TImplementor : TAccessor {
        var type = typeof(TAccessor);
        if (Dependencies.ContainsKey(type)) {
            throw new ArgumentException("Dependency already registered");
        }

        var instance = Activator.CreateInstance(typeof(TImplementor), args)!;
        
        var dependencyType = DependencyType.Singleton;
        if (type.GetCustomAttributes().SingleOrDefault(attr => attr is DependencyAttribute) is DependencyAttribute attribute)
            dependencyType = attribute.Type;

        switch (dependencyType) {
            case DependencyType.Scoped:
                break;
            
            case DependencyType.Singleton:
            default:
                Dependencies.Add(type, instance);
                break;
        }
        
        return (TAccessor)instance;
    }
}