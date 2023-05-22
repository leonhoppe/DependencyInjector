namespace DependencyInjector.Test; 

[Dependency(Type = DependencyType.Singleton)]
public class Config {

    public string Message { get; set; } = Dependency.Inject<IMessageCreator>().CreateMessage("Hello World!");

}