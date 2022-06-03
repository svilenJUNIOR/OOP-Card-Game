﻿using BelotCardGame.Contracts;
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

//try
//{
//    engine.Run();
//}
//catch (ArgumentException e)
//{
//    Console.WriteLine(e.Message);
//}
engine.Run();


