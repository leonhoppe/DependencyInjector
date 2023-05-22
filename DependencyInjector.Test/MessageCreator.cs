namespace DependencyInjector.Test; 

public class MessageCreator : IMessageCreator {

    public string CreateMessage(string message) => message;

    public MessageCreator() {
        Console.WriteLine(1);
    }

}