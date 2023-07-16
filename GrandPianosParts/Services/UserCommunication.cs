using GrandPianosParts.Entities;
using GrandPianosParts.Repositories;
using GrandPianosParts.Services.ServiceProviders;


namespace GrandPianosParts.Services
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<PianoParts> _pianoPartsRepository;
       
        private readonly IUserCommunicationProvider _userCommunicationProvider;

        public UserCommunication
            (IRepository<PianoParts> pianoPartsRepository,
            IUserCommunicationProvider userCommunicationProvider)
        {
            _pianoPartsRepository = pianoPartsRepository;          
            _userCommunicationProvider = userCommunicationProvider;
        }

        public void Communication()
        {
            Console.WriteLine("Welcome to Grand piano parts repository app.");
            Console.WriteLine("Your part list will be store in database included of this app");
            Console.WriteLine("--------------------------------------------------------------\n");


            bool chose = true;
            do
            {
                try
                {

                    Console.WriteLine("Would you like to open previous data?");
                    Console.WriteLine("press: y/n ");
                    Console.WriteLine();
                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "y":
                          {                                
                                _pianoPartsRepository.Open();
                                chose = false;
                                break;
                            }
                        case "n":
                            {
                                Console.WriteLine();
                                Console.WriteLine("Your data will not be restored ");
                                Console.WriteLine();
                                chose = false;
                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid character \n");

                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                }

            } while (chose);


            bool outLoop = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------");
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
                            _userCommunicationProvider.WriteAll(_pianoPartsRepository);
                            try
                            {
                                Console.WriteLine("\n Do You want to sort those position? y/n ");
                                Console.WriteLine();
                                userInput = Console.ReadLine();
                                if (userInput == "y")
                                {
                                    _userCommunicationProvider.SortMenu();
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
                            _userCommunicationProvider.AddItem(_pianoPartsRepository);
                            break;
                        }
                    case "r":
                        {
                            _userCommunicationProvider.RemoveItemById(_pianoPartsRepository);
                            break;
                        }
                    case "q":
                        {
                            _pianoPartsRepository.Save();
                            outLoop = false;
                            break;
                        }
                }
            } while (outLoop);            
        }
    }
}
