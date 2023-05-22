namespace DependencyInjector; 

public interface IDependencyProvider {
    protected IDictionary<Type, object> Dependencies { get; }

    public T Inject<T>(params object[] args);
    public T Provide<T>(params object[] args);
    public TAccessor Provide<TAccessor, TImplementor>(params object[] args) where TImplementor : TAccessor;
}