
using GrandPianosParts.Data;
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;

var sqlRepository = new SqlRepository<PianoParts>(new ApplicationDbContext());
AddHammers(sqlRepository);
AddSchanks(sqlRepository);

WriteAll(sqlRepository);


static void AddSchanks(IWriteRepository<Schank> schankRepository)
{
    schankRepository.Add(new Schank { PartName = "17 Schank", PartNumber = "123012", Producer = 'A' });
    schankRepository.Add(new Schank { PartName = "16.2 Schank", PartNumber = "3212", Producer = 'R' });
    schankRepository.Add(new Schank { PartName = "15.5 Schank", PartNumber = "3212", Producer = 'J' });
    schankRepository.Save();
}

static void AddHammers(IWriteRepository<Hammer> hammerRepository)
{
    hammerRepository.Add(new Hammer { PartName = "SS original Hammer", PartNumber = "1302", Producer = 'S' });
    hammerRepository.Add(new Hammer { PartName = "Bechstein Hammer", PartNumber = "1012", Producer = 'R' });
    hammerRepository.Add(new Hammer { PartName = "Bluthner Patent Hammer", PartNumber = "410", Producer = 'A' });
    hammerRepository.Save();
}

static void WriteAll(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}