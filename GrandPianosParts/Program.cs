
using GrandPianosParts;
using GrandPianosParts.DataProviders;
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using GrandPianosParts.Services;
using GrandPianosParts.Services.ServiceProviders;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IRepository<PianoParts>,ListRepository<PianoParts>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandler, GrandPianosParts.Services.EventHandler>();
services.AddSingleton<IPartsProvider, PartsProvider>();
services.AddSingleton<IUserCommunicationProvider, UserCommunicationProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();


