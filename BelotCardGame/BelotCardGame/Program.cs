using BelotCardGame.Contracts;
using BelotCardGame.Models;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<IPlayer, Player>()
    .AddScoped<IComputer, Computer>()
    .AddScoped<IDealer, Dealer>()
    .AddScoped<IEngine, Engine>()
    .BuildServiceProvider();

IEngine engine = serviceProvider.GetService<IEngine>();
engine.Run();



