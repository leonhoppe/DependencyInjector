// See https://aka.ms/new-console-template for more information

using DependencyInjector;
using DependencyInjector.Test;

Dependency.Provide<IMessageCreator, MessageCreator>();

var config = Dependency.Inject<Config>();
var creator = Dependency.Inject<IMessageCreator>();
Console.WriteLine(config.Message);
Console.WriteLine(creator.CreateMessage("Test"));
