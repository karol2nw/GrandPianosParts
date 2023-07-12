
using GrandPianosParts;
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using GrandPianosParts.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IRepository<PianoParts>,ListRepository<PianoParts>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandler, GrandPianosParts.Services.EventHandler>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();


//using GrandPianosParts.Data;
//using GrandPianosParts.Entities;
//using GrandPianosParts.Repositories;


//const string auditFile = "Audit.txt";
//Console.WriteLine("Welcome to Grand piano parts repository app.");
//Console.WriteLine("Your part list will be store in database included of this app");
//Console.WriteLine("--------------------------------------------------------------");

//Console.WriteLine("At first, tell me where do you want to save data?");
//Console.WriteLine("To work on your database in file, press '1'");
//Console.WriteLine("To work on your database in SQL Server, press '2'");

//IRepository<PianoParts> _pianoPartsRepository = null;
//var userInput = Console.ReadLine();
//try
//{
//    if (userInput == "1")
//    {
//        _pianoPartsRepository = ListRepositoryCreator();
//    }
//    else if (userInput == "2")
//    {
//        _pianoPartsRepository = SqlRepositoryCretor();
//    }
//    else
//    {
//        throw new Exception("Invalid character");
//    }
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}

//_pianoPartsRepository.ItemAdded += ItemAdded;
//_pianoPartsRepository.ItemRemoved += ItemRemoved;
//_pianoPartsRepository.ItemSaved += ItemSaved;



//Console.WriteLine();
//Console.WriteLine("Would you like to open previous data?");
//Console.WriteLine("press: y/n ");
//try
//{
//    userInput = Console.ReadLine();
//    if (userInput == "y")
//    {
//        try
//        {
//            _pianoPartsRepository.Open();
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }

//    }
//    else if (userInput == "n")
//    {
//        Console.WriteLine("Your data will not be restored ");
//    }
//    else
//    {
//        throw new Exception("Invalid character");
//    }
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}

//bool outLoop = true;
//do
//{
//    Console.WriteLine();
//    Console.WriteLine("-------------------------------------");
//    Console.WriteLine("What do You want to do ?");
//    Console.WriteLine("To show all parts press 'a'");
//    Console.WriteLine("To Add new part press 'n'");
//    Console.WriteLine("To remove part press 'r'");
//    Console.WriteLine("To save changes press 's'");
//    Console.WriteLine("To quit data managment press 'q'");
//    userInput = Console.ReadLine();

//    switch (userInput)
//    {

//        case "a":
//            {
//                WriteAll(_pianoPartsRepository);
//                break;
//            }
//        case "n":
//            {
//                AddItem(_pianoPartsRepository);
//                break;
//            }
//        case "r":
//            {
//                RemoveItemById(_pianoPartsRepository);
//                break;
//            }
//        case "s":
//            {
//                _pianoPartsRepository.Save();
//                break;
//            }
//        case "q":
//            {
//                outLoop = false;
//                break;
//            }
//    }
//} while (outLoop);

//static void AddItem(IRepository<PianoParts> repository)
//{
//    while (true)
//    {
//        Console.WriteLine("insert part type : 1 - schank , 2 - hammer , 3- damperfilz or q - to quit data entry");
//        var userInput = Console.ReadLine();
//        var type = userInput;

//        if (type == "1")
//        {
//            Console.WriteLine("insert Part Name :");
//            userInput = Console.ReadLine();
//            var partName = userInput;
//            Console.WriteLine("Insert Part Number :");
//            userInput = Console.ReadLine();
//            var partNumber = userInput;
//            Console.WriteLine("Insert producer :");
//            userInput = Console.ReadLine();
//            try
//            {
//                if (char.TryParse(userInput, out var producer))
//                {
//                    repository.Add(new Schank { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
//                }
//                else
//                {
//                    throw new Exception("Input only one character");
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        else if (type == "2")
//        {
//            Console.WriteLine("insert Part Name :");
//            userInput = Console.ReadLine();
//            var partName = userInput;
//            Console.WriteLine("Insert Part Number :");
//            userInput = Console.ReadLine();
//            var partNumber = userInput;
//            Console.WriteLine("Insert producer :");
//            userInput = Console.ReadLine();
//            var producer = char.Parse(userInput);

//            repository.Add(new Hammer { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
//        }
//        else if (type == "3")
//        {
//            Console.WriteLine("insert Part Name :");
//            userInput = Console.ReadLine();
//            var partName = userInput;
//            Console.WriteLine("Insert Part Number :");
//            userInput = Console.ReadLine();
//            var partNumber = userInput;
//            Console.WriteLine("Insert producer :");
//            userInput = Console.ReadLine();
//            var producer = char.Parse(userInput);

//            repository.Add(new DamperFilz { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
//        }
//        if (type == "q")
//        {
//            break;
//        }
//    }
//}
//static void ItemAdded(object sender, PianoParts item)
//{
//    Console.WriteLine($"{item.PartName} id: {item.Id} added");
//    using (var writer = File.AppendText(auditFile))
//    {
//        writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} added");
//    }
//}
//static void ItemRemoved(object sender, PianoParts item)
//{
//    Console.WriteLine($"{item.PartName} id: {item.Id} removed");
//    using (var writer = File.AppendText(auditFile))
//    {
//        writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} removed");
//    }
//}
//static void ItemSaved(object sender, PianoParts item)
//{
//    Console.WriteLine($"{item.PartName} id: {item.Id} saved");
//    using (var writer = File.AppendText(auditFile))
//    {
//        writer.WriteLine($"{DateTime.Now} : {item.PartName} id: {item.Id} saved");
//    }
//}


//static void WriteAll(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}
//static void RemoveItemById(IRepository<PianoParts> repository)
//{
//    try
//    {
//        Console.WriteLine("Insert item Id to remove");
//        if (int.TryParse(Console.ReadLine(), out var id))
//        {
//            var item = repository.GetById(id);
//            repository.Remove(item);
//        }
//        else
//        {
//            throw new Exception("Invalid Id value");
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//static ListRepository<PianoParts> ListRepositoryCreator()
//{
//    var repository = new ListRepository<PianoParts>();

//    return repository;
//}
//static SqlRepository<PianoParts> SqlRepositoryCretor()
//{
//    var repository = new SqlRepository<PianoParts>(new ApplicationDbContext());
//    return repository;
//}

