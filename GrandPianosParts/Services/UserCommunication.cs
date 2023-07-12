using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandPianosParts.Services
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<PianoParts> _pianoPartsRepository;


        public UserCommunication(IRepository<PianoParts> pianoPartsRepository)
        {
            _pianoPartsRepository = pianoPartsRepository;
        }

        public void Communication()
        {

            Console.WriteLine("Welcome to Grand piano parts repository app.");
            Console.WriteLine("Your part list will be store in database included of this app");
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Would you like to open previous data?");
            Console.WriteLine("press: y/n ");
            var userInput = Console.ReadLine();
            try
            {
                
                if (userInput == "y")
                {
                    try
                    {
                        Open(_pianoPartsRepository);
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


            bool outLoop = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("What do You want to do ?");
                Console.WriteLine("To show all parts press 'a'");
                Console.WriteLine("To Add new part press 'n'");
                Console.WriteLine("To remove part press 'r'");
                Console.WriteLine("To save changes press 's'");
                Console.WriteLine("To quit data managment press 'q'");
                userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "a":
                        {
                            WriteAll(_pianoPartsRepository);
                            break;
                        }
                    case "n":
                        {
                            AddItem(_pianoPartsRepository);
                            break;
                        }
                    case "r":
                        {
                            RemoveItemById(_pianoPartsRepository);
                            break;
                        }
                    case "s":
                        {
                            _pianoPartsRepository.Save();
                            break;
                        }
                    case "q":
                        {
                            outLoop = false;
                            break;
                        }
                }
            } while (outLoop);

            static void AddItem(IRepository<PianoParts> repository)
            {
                while (true)
                {
                    Console.WriteLine("insert part type : \n" +
                        " 1 - schank \n" +
                        " 2 - hammer \n" +
                        " 3 - damperfilz \n " +
                        "q - to quit data entry");
                    var userInput = Console.ReadLine();
                    var type = userInput;

                    if (type == "1")
                    {
                        Console.WriteLine("insert Part Name :");
                        userInput = Console.ReadLine();
                        var partName = userInput;
                        Console.WriteLine("Insert Part Number :");
                        userInput = Console.ReadLine();
                        var partNumber = userInput;
                        Console.WriteLine("Insert producer :");
                        userInput = Console.ReadLine();
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
                        Console.WriteLine("insert Part Name :");
                        userInput = Console.ReadLine();
                        var partName = userInput;
                        Console.WriteLine("Insert Part Number :");
                        userInput = Console.ReadLine();
                        var partNumber = userInput;
                        Console.WriteLine("Insert producer :");
                        userInput = Console.ReadLine();
                        var producer = char.Parse(userInput);

                        repository.Add(new Hammer { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
                    }
                    else if (type == "3")
                    {
                        Console.WriteLine("insert Part Name :");
                        userInput = Console.ReadLine();
                        var partName = userInput;
                        Console.WriteLine("Insert Part Number :");
                        userInput = Console.ReadLine();
                        var partNumber = userInput;
                        Console.WriteLine("Insert producer :");
                        userInput = Console.ReadLine();
                        var producer = char.Parse(userInput);

                        repository.Add(new DamperFilz { PartName = $"{partName}", PartNumber = $"{partNumber}", Producer = producer });
                    }
                    if (type == "q")
                    {
                        break;
                    }
                }
            }
            static void WriteAll(IReadRepository<IEntity> repository)
            {
                var items = repository.GetAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            static void RemoveItemById(IRepository<PianoParts> repository)
            {
                try
                {
                    Console.WriteLine("Insert item Id to remove");
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
            static void Open(IRepository<PianoParts> repository)
            {
                repository.Open();
            }
        }
    }
}
