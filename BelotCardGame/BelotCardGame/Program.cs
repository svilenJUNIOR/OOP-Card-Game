using BelotCardGame.Constants;
using BelotCardGame.Contracts;
using BelotCardGame.InputOutput;
using BelotCardGame.InputOutput.Contracts;
using BelotCardGame.Models;
using BelotCardGame.Services;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<IPlayer, Player>()
    .AddScoped<IComputer, Computer>()
    .AddScoped<IDealer, Dealer>()
    .AddScoped<IEngine, Engine>()
    .AddScoped<IScoreBoard, ScoreBoard>()
    .AddScoped<IDealerService, DealerService>()
    .AddScoped<IWriter, Writer>()
    .AddScoped<Values, Values>()
    .BuildServiceProvider();

IEngine engine = serviceProvider.GetService<IEngine>();

//try
//{
//    engine.Run();
//}
//catch (ArgumentException e)
//{
//    Console.WriteLine(e.Message);
//}
engine.Run();


