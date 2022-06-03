using BelotCardGame.Contracts;
using BelotCardGame.Models;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<IPlayer, Player>()
    .AddScoped<IComputer, Computer>()
    .AddScoped<IDealer, Dealer>()
    .AddScoped<IEngine, Engine>()
    .AddScoped<IScoreBoard, ScoreBoard>()
    .BuildServiceProvider();

IEngine engine = serviceProvider.GetService<IEngine>();

try
{
    engine.Run();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}



