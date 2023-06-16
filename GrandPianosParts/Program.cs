
using GrandPianosParts.Data;
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using GrandPianosParts.Repositories.RepositoryExtensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;

Console.WriteLine("Welcome to Grand piano parts repository app.");
Console.WriteLine("Your part list will be store in data base included of this app");
Console.WriteLine("--------------------------------------------------------------");

Console.WriteLine("At first, tell me where do you want to save data?");
Console.WriteLine("To work on your database in file, press '1'");
Console.WriteLine("To work on your database in SQL Server, press '2'");



IRepository<PianoParts> repository = null;
var userInput = Console.ReadLine();
try
{
    
    if (userInput == "1")
    {
      repository =  ListRepositoryCreator();
        
    }
    else if (userInput == "2")
    {
        SqlRepositoryCretor();
    }
    else
    {
        throw new Exception("Invalid character");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


Console.WriteLine();
Console.WriteLine("Would you like to open previous data?");
Console.WriteLine("press: y/n ");

try
{
    userInput = Console.ReadLine();
    if (userInput == "y") 
    {
        try
        {
            repository.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    else if (userInput == "n")
    {
        Console.WriteLine("Your data will not be restored ");
    }
    else
    {
        throw new Exception("Invalid character");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}





repository.ItemAdded += ItemAdded;
repository.ItemRemoved += ItemRemoved;
repository.ItemAdded += ItemAdded;
repository.ItemRemoved += ItemRemoved;


static void ItemAdded(object? sender, IEntity item)
{
    Console.WriteLine($"{item.PartName} id: {item.Id} added");
}
static void ItemRemoved(object sender, IEntity item)
{
    Console.WriteLine($"{item.PartName} id: {item.Id} removed");
}



//var schanks = new[]
//{
//        new Schank { PartName = "17 Schank", PartNumber = "123012", Producer = 'A' },
//        new Schank { PartName = "16.2 Schank", PartNumber = "3212", Producer = 'R' },
//        new Schank { PartName = "15.5 Schank", PartNumber = "3212", Producer = 'J' }
//};
//sqlRepository.AddBatch(schanks);





//var hammers = new[]
//{
//        new Hammer { PartName = "SS original Hammer", PartNumber = "1302", Producer = 'S' },
//        new Hammer { PartName = "Bechstein Hammer", PartNumber = "1012", Producer = 'R' },
//        new Hammer { PartName = "Bluthner Patent Hammer", PartNumber = "410", Producer = 'A' }
//    };
//sqlRepository.AddBatch(hammers);


WriteAll(repository);

static void WriteAll(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static ListRepository<PianoParts> ListRepositoryCreator()
{
    var repository = new ListRepository<PianoParts>();

    return repository;
}
static SqlRepository<PianoParts> SqlRepositoryCretor()
{
    var repository = new SqlRepository<PianoParts>(new ApplicationDbContext());
    return repository;
}