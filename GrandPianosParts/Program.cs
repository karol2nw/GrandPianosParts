
using GrandPianosParts;
using GrandPianosParts.Components.DataProviders;
using GrandPianosParts.Data.Entities;
using GrandPianosParts.Data.Repositories;
using GrandPianosParts.Services;

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
//services.AddSingleton<IRepository<PianoParts>,ListRepository<PianoParts>>();
services.AddSingleton<IRepository<Hammer>,ListRepository<Hammer>>();
services.AddSingleton<IRepository<DamperFilz>, ListRepository<DamperFilz>>();
services.AddSingleton<IRepository<Schank>,ListRepository<Schank>>();


services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandler, GrandPianosParts.Services.EventHandler>();
services.AddSingleton<IPartsProvider, PartsProvider>();



var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();


