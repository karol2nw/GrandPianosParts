using GrandPianosParts.DataProviders;
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;


namespace GrandPianosParts.Services.ServiceProviders
{
    public class UserCommunicationProvider : IUserCommunicationProvider
    {
        private readonly IPartsProvider _partsProvider;

        public UserCommunicationProvider
            (IPartsProvider partsProvider)
        {
            _partsProvider = partsProvider;
        }

        public void AddItem(IRepository<PianoParts> repository)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("insert part type : \n" +
                    "-------------------------------------- \n" +
                    " 1 - schank \n" +
                    " 2 - hammer \n" +
                    " 3 - damperfilz \n " +
                    "q - to quit data entry \n");
                var userInput = Console.ReadLine();
                var type = userInput;

                if (type == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("insert Part Name : \n");
                    userInput = Console.ReadLine();
                    var partName = userInput;
                    Console.WriteLine();
                    Console.WriteLine("Insert Part Number : \n");
                    userInput = Console.ReadLine();
                    var partNumber = userInput;
                    Console.WriteLine();
                    Console.WriteLine("Insert producer : \n");
                    userInput = Console.ReadLine().ToLower();
                    try
                    {
                        if (char.TryParse(userInput, out var producer))
                        {
                            repository.Add(new Schank { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
                        }
                        else
                        {
                            throw new Exception("Input only one character");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (type == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("insert Part Name : \n");
                    userInput = Console.ReadLine();
                    var partName = userInput;
                    Console.WriteLine();
                    Console.WriteLine("Insert Part Number : \n");
                    userInput = Console.ReadLine();
                    var partNumber = userInput;
                    Console.WriteLine();
                    Console.WriteLine("Insert producer : \n");
                    userInput = Console.ReadLine().ToLower();
                    try
                    {
                        if (char.TryParse(userInput, out var producer))
                        {
                            repository.Add(new Hammer { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
                        }
                        else
                        {
                            throw new Exception("Input only one character");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else if (type == "3")
                {
                    Console.WriteLine();
                    Console.WriteLine("insert Part Name :");
                    userInput = Console.ReadLine();
                    var partName = userInput;
                    Console.WriteLine();
                    Console.WriteLine("Insert Part Number :");
                    userInput = Console.ReadLine();
                    var partNumber = userInput;
                    Console.WriteLine();
                    Console.WriteLine("Insert producer :");
                    userInput = Console.ReadLine().ToLower();
                    try
                    {
                        if (char.TryParse(userInput, out var producer))
                        {
                            repository.Add(new DamperFilz { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
                        }
                        else
                        {
                            throw new Exception("Input only one character");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (type == "q")
                {
                    break;
                }
            }
        }

        public void WriteAll(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void RemoveItemById(IRepository<PianoParts> repository)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Insert item Id to remove \n");
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    var item = repository.GetById(id);
                    repository.Remove(item);
                }
                else
                {
                    throw new Exception("Invalid Id value");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SortMenu()
        {
            bool sortMenu = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("choose what would you like to sort positions?");
                Console.WriteLine("----------------------------------------------\n");
                Console.WriteLine
                    ("To sort all positions press 'o' \n" +
                    "To Show  the designated items press 'w' \n" +
                    "To show only one kind of parts press 'k' \n" +
                    "To show only parts numbers press 'n' \n" +
                    "To show only parts Names press 'p' \n" +
                    "To show distinct producers chars included in repository press 'c' \n" +
                    "To quit data view manager press 'q' \n ");

                var userInput = Console.ReadLine();
                Console.WriteLine();


                try
                {
                    switch (userInput)
                    {
                        case "o":
                            {
                                Console.WriteLine();
                                OrderBy();
                                break;
                            }
                        case "w":
                            {
                                Console.WriteLine();
                                WherePart();
                                break;
                            }
                        case "k":
                            {
                                Console.WriteLine();
                                ShowOnlyKindParts();
                                break;
                            }
                        case "n":
                            {
                                Console.WriteLine();
                                var items = _partsProvider.ShowPartsNumbers();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case "p":
                            {
                                Console.WriteLine();
                                var items = _partsProvider.ShowPartsNames();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case "c":
                            {
                                Console.WriteLine();
                                var items = _partsProvider.ShowProducersDistinct();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case "q":
                            {
                                sortMenu = false;
                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid character");
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (sortMenu);
        }

        public void OrderBy()
        {
            bool orderBy = true;

            do
            {
                Console.WriteLine
                ("To sort data by producer prss 'p' \n" +
                "To sort data by name press 'n' \n" +
                "To sort data by Id press 'i' \n" +
                "To quit data sort press 'q' \n");
                var userInput = Console.ReadLine();

                try
                {
                    switch (userInput)
                    {
                        case "p":
                            {
                                Console.WriteLine();
                                var items = _partsProvider.OrderByProducer();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine();
                                break;
                            }
                        case "n":
                            {
                                Console.WriteLine();
                                var items = _partsProvider.OrderByName();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine();
                                break;
                            }
                        case "i":
                            {
                                Console.WriteLine();
                                var items = _partsProvider.OrderById();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine();
                                break;
                            }
                        case "q":
                            {
                                orderBy = false;
                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid character");
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (orderBy);

        }

        public void WherePart()
        {
            bool wherePart = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine
               ("To show all parts of a specific producer press 'p' \n" +
                "To show all parts of a specific number press 'n' \n" +
                "To quit specyfic data showing press 'q' \n ");
                var userInput = Console.ReadLine();
                try
                {
                    switch (userInput)
                    {
                        case "p":
                            {
                                Console.WriteLine();
                                Console.WriteLine("Insert producer character (a, r, s, j) \n");
                                userInput = Console.ReadLine();
                                if (Char.TryParse(userInput, out var producer))
                                {
                                    if (producer == 'a')
                                    {
                                        Console.WriteLine();
                                        var items = _partsProvider.WhereProdcerIs('a');
                                        foreach (var item in items)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine();
                                    }
                                    else if (producer == 'r')
                                    {
                                        Console.WriteLine();
                                        var items = _partsProvider.WhereProdcerIs('r');
                                        foreach (var item in items)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine();
                                    }
                                    else if (producer == 's')
                                    {
                                        Console.WriteLine();
                                        var items = _partsProvider.WhereProdcerIs('s');
                                        foreach (var item in items)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine();
                                    }
                                    else if (producer == 'j')
                                    {
                                        Console.WriteLine();
                                        var items = _partsProvider.WhereProdcerIs('j');
                                        foreach (var item in items)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        throw new Exception("Invalid producer character \n");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Insert only one character \n");
                                }
                                break;
                            }
                        case "n":
                            {
                                Console.WriteLine();
                                Console.WriteLine("Insert parts number \n");
                                userInput = Console.ReadLine();

                                Console.WriteLine();
                                var items = _partsProvider.WhereNumberIs(userInput);
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case "q":
                            {
                                wherePart = false;
                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid character");
                            }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (wherePart);


        }

        public void ShowOnlyKindParts()
        {
            bool showOnlyKindParts = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What kind od parts would You like to see ? \n");
                Console.WriteLine
                   ("To show all hammers press 'h' \n" +
                    "To show all schanks press 's' \n" +
                    "To show all damperfilz press 'd' \n" +
                    "To quit data showing press 'q' \n");

                var userInput = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    switch (userInput)
                    {
                        case "h":
                            {
                                var items = _partsProvider.ShowAllHammers();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case "s":
                            {
                                var items = _partsProvider.ShowAllSchanks();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case "d":
                            {
                                var items = _partsProvider.ShowAllDampers();
                                foreach (var item in items)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            }
                        case "q":
                            {
                                showOnlyKindParts = false;
                                break;

                            }
                        default:
                            {
                                throw new Exception("Invalid character");
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (showOnlyKindParts);
        }
    }
}
