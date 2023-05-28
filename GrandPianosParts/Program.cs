
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;

var listRepo = new ListRepository<Hammer>();

listRepo.Add(new Hammer { PartName = "ss hammer", PartNumber = "123456", Producer = 'S' });
listRepo.Add(new Hammer { PartName = "ss hammer", PartNumber = "1234567", Producer = 'A' });
listRepo.Add(new Hammer { PartName = "ss hammer", PartNumber = "1234568", Producer = 'R' });


Console.WriteLine(listRepo.GetById(2));
