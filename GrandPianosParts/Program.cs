
using GrandPianosParts.Data;
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using GrandPianosParts.Repositories.RepositoryExtensions;

var sqlRepository = new ListRepository<PianoParts>()/*(new ApplicationDbContext())*/;
sqlRepository.ItemAdded += ItemAdded;
sqlRepository.ItemRemoved += ItemRemoved;


static void ItemAdded(object sender, PianoParts item)
{
    Console.WriteLine($"{item.PartName} id: {item.Id} added");
}
static void ItemRemoved(object sender, PianoParts item)
{
    Console.WriteLine($"{item.PartName} id: {item.Id} removed");
}

var schanks = new[]
{
        new Schank { PartName = "17 Schank", PartNumber = "123012", Producer = 'A' },
        new Schank { PartName = "16.2 Schank", PartNumber = "3212", Producer = 'R' },
        new Schank { PartName = "15.5 Schank", PartNumber = "3212", Producer = 'J' }
};
sqlRepository.AddBatch(schanks);





    var hammers = new[]
    {
        new Hammer { PartName = "SS original Hammer", PartNumber = "1302", Producer = 'S' },
        new Hammer { PartName = "Bechstein Hammer", PartNumber = "1012", Producer = 'R' },
        new Hammer { PartName = "Bluthner Patent Hammer", PartNumber = "410", Producer = 'A' }
    };
sqlRepository.AddBatch(hammers);


WriteAll(sqlRepository);

static void WriteAll(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}