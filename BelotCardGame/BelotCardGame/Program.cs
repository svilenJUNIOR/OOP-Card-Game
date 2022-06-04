using BelotCardGame.Engine;
using BelotCardGame.Infrastructure.Constants;
using BelotCardGame.Infrastructure.Contracts;
using BelotCardGame.Infrastructure.InputOutput;
using BelotCardGame.Infrastructure.InputOutput.Contracts;
using BelotCardGame.Infrastructure.Models;
using BelotCardGame.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<IPlayer, Player>()
    .AddScoped<IComputer, Computer>()
    .AddScoped<IDealer, Dealer>()
    .AddScoped<IEngine, Engine>()
    .AddScoped<IScoreBoard, ScoreBoard>()
    .AddScoped<IDealerService, DealerService>()
    .AddScoped<IWriter, Writer>()
    .AddScoped<IReader, Reader>()
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


