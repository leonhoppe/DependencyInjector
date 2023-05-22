namespace DependencyInjector;

[AttributeUsage(validOn: AttributeTargets.Class)]
public sealed class DependencyAttribute : Attribute {

    public DependencyType Type { get; set; } = DependencyType.Singleton;

}

public enum DependencyType : byte {
    Singleton = 0x00,
    Scoped = 0x01
}
