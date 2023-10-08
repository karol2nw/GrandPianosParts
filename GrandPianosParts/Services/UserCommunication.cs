using GrandPianosParts.DataProviders;
using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;



namespace GrandPianosParts.Services
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Hammer> _hammerRepository;
        private readonly IRepository<Schank> _schankRepository;
        private readonly IRepository<DamperFilz> _damperRepository;
        private readonly IPartsProvider _partsProvider;

        public UserCommunication
            (IRepository<Hammer> hammerRepository,
            IRepository<Schank> schankRepository,
            IRepository<DamperFilz> damperRepository,
            IPartsProvider partsProvider)
        {
            _hammerRepository = hammerRepository;
            _schankRepository = schankRepository;
            _damperRepository = damperRepository;
            _partsProvider = partsProvider;
        }

        public void Communication()
        {
            Intro();

            _hammerRepository.Open();
            _schankRepository.Open();
            _damperRepository.Open();


            bool outLoop = true;
            do
            {

                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("What do You want to do ? \n");
                Console.WriteLine("To show all parts press 'a'");
                Console.WriteLine("To Add new part press 'n'");
                Console.WriteLine("To remove part press 'r'");
                Console.WriteLine("To save changes & quit data managment press 'q' \n");
                var userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "a":
                        {
                            Console.WriteLine();
                            WriteAll(_hammerRepository);
                            WriteAll(_schankRepository);
                            WriteAll(_damperRepository);

                            try
                            {
                                Console.WriteLine("\n Do You want to sort those position? y/n ");
                                Console.WriteLine();
                                userInput = Console.ReadLine();
                                if (userInput == "y")
                                {
                                    SortMenu();
                                }
                                else if (userInput == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    throw new Exception("Ivalid character");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case "n":
                        {
                            AddMenu();
                            break;
                        }
                    case "r":
                        {
                            RemoveMenu();
                            break;
                        }
                    case "q":
                        {
                            _hammerRepository.Save();
                            _schankRepository.Save();
                            _damperRepository.Save();
                            outLoop = false;
                            break;
                        }
                }
            } while (outLoop);
        }

        private void Intro()
        {
            Console.WriteLine("Welcome to Grand piano parts repository app.");
            Console.WriteLine("Your part list will be store in database included of this app");
            Console.WriteLine("--------------------------------------------------------------\n");

        }
        private void WriteAll(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        private void AddMenu()
        {
            bool addMenu = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("insert part type : \n" +
                    "-------------------------------------- \n" +
                    " 1 - schank \n" +
                    " 2 - hammer \n" +
                    " 3 - damperfilz \n " +
                    "q - to quit data entry \n");

                var type = Console.ReadLine();

                if (type == "q")
                {
                    addMenu = false;
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("insert Part Name : \n");
                var partName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Insert Part Number : \n");
                var partNumber = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Insert producer : \n");
                var producer = Console.ReadLine().ToLower();
                char.TryParse(producer, out char producerLetter);

                switch (type)
                {
                    case "1":
                        {
                            _schankRepository.Add(new Schank { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producerLetter });
                            break;
                        }
                    case "2":
                        {
                            _hammerRepository.Add(new Hammer { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producerLetter });
                            break;
                        }
                    case "3":
                        {
                            _damperRepository.Add(new DamperFilz { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producerLetter });
                            break;
                        }
                }

            } while (addMenu);
        }
        private void RemoveMenu()
        {
            Console.WriteLine("Select part type to remove \n " +
                " 1 - hammer / 2 - schank / 3 - damper \n");
            var type = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("insert part Id to remove \n");
            var idString = Console.ReadLine();
            int.TryParse(idString, out int id);
            switch (type)
            {
                case "1":
                    {
                        var hammerToRemove = _hammerRepository.GetById(id);
                        _hammerRepository.Remove(hammerToRemove);
                        break;
                    }
                case "2":
                    {
                        var schankToRemove = _schankRepository.GetById(id);
                        _schankRepository.Remove(schankToRemove);
                        break;
                    }
                case "3":
                    {
                        var damperToRemove = _damperRepository.GetById(id);
                        _damperRepository.Remove(damperToRemove);
                        break;
                    }
            }
        }
        private void SortMenu()
        {
            bool sortMenu = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("choose what would you like to sort positions?");
                Console.WriteLine("----------------------------------------------\n");
                Console.WriteLine
                    ("To sort all positions by name press 'o' \n" +
                    "To show only one kind of parts press 'k' \n" +
                    "To show all part names press 'c' \n" +
                    "To show all part numbers press 'n' \n" +
                    "To find all parts including specyfic numer press 'i' \n" +
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
                                var hammers = _partsProvider.OrderHammersByName();

                                foreach (var hammer in hammers)
                                {
                                    Console.WriteLine(hammer);
                                }

                                var schanks = _partsProvider.OrderSchanksByName();
                                foreach (var schank in schanks)
                                {
                                    Console.WriteLine(schank);
                                }

                                var dampers = _partsProvider.OrderDampersByName();
                                foreach (var damper in dampers)
                                {
                                    Console.WriteLine(damper);
                                }

                                Console.WriteLine();
                                break;
                            }

                        case "k":
                            {
                                Console.WriteLine();
                                ShowOnlyKindParts();
                                break;
                            }
                        case "c":
                            {
                                Console.WriteLine();
                                var hammerNames = _partsProvider.ShowAllHammersName();
                                foreach (var hammerName in hammerNames)
                                {
                                    Console.WriteLine(hammerName);
                                }
                                var schankNames = _partsProvider.ShowAllSchanksName();
                                foreach (var schankName in schankNames)
                                {
                                    Console.WriteLine(schankName);
                                }
                                var damperNames = _partsProvider.ShowAllDampersName();
                                foreach (var damperName in damperNames)
                                {
                                    Console.WriteLine(damperName);
                                }

                                break;
                            }
                        case "n":
                            {
                                Console.WriteLine();
                                var hammerNumbers = _partsProvider.ShowAllHammersNumber();
                                foreach (var hammerNumber in hammerNumbers)
                                {
                                    Console.WriteLine(hammerNumber);
                                }
                                var schankNumbers = _partsProvider.ShowAllSchanksNumber();
                                foreach (var schankNumber in schankNumbers)
                                {
                                    Console.WriteLine(schankNumber);
                                }
                                var damperNumbers = _partsProvider.ShowAllDampersNumber();
                                foreach (var damperNumber in damperNumbers)
                                {
                                    Console.WriteLine(damperNumber);
                                }

                                break;
                            }
                        case "i":
                            {
                                Console.WriteLine();
                                Console.WriteLine("Insert number ");
                                var number = Console.ReadLine();
                                var hammers = _partsProvider.WhereHammerNumberIs(number);
                                foreach (var hammer in hammers)
                                {
                                    Console.WriteLine(hammer);
                                }
                                var schanks = _partsProvider.WhereSchankNumberIs(number);
                                foreach (var schank in schanks)
                                {
                                    Console.WriteLine(schank);
                                }
                                var dampers = _partsProvider.WhereDamperNumberIs(number);
                                foreach (var damper in dampers)
                                {
                                    Console.WriteLine(damper);
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
        private void ShowOnlyKindParts()
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
