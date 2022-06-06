using BelotCardGame.Models.Contracts;
using BelotCardGame.Models.Models;
using BelotCardGame.Services.Constants;
using BelotCardGame.Services.Contracts;
using BelotCardGame.Services.InputOutput;
using BelotCardGame.Services.InputOutput.Contracts;
using BelotCardGame.Services.Services;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<Player, Player>()
    .AddScoped<Computer, Computer>()
    .AddScoped<IEngine, Engine>()
    .AddScoped<IScoreBoard, ScoreBoard>()
    .AddScoped<IGameService, GameService>()
    .AddScoped<IWriter, Writer>()
    .AddScoped<IReader, Reader>()
    .AddScoped<IPlayerService, PlayerService>()
    .AddScoped<IComputerService, ComputerService>()
    .AddScoped<Values, Values>()
    .BuildServiceProvider();

IEngine engine = serviceProvider.GetService<IEngine>();

try
{
    engine.Run();
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}