using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class LibraryMenu
    {
        public static void List()
        {
            int option;
            AddressBookLibrary mylibrary = new AddressBookLibrary();
            do
            {
                Console.Clear();
                Console.WriteLine("-------------Address Books Library-------------");
                Console.WriteLine("Choose from following:\n");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Open an AddressBook");
                Console.WriteLine("3. Display all Address Books in library");
                Console.WriteLine("4. Exit");
                Console.WriteLine("5. Search and filter by location");
                Console.WriteLine("6. Get City wise count");
                Console.WriteLine("7. Exit");
                option = Userinput.GetPositiveInt("Enter option(1-7): ");
                Console.Clear();
                switch (option)
                {
                    case 1:
                        mylibrary.AddAddressBook();
                        break;
                    case 2:
                        mylibrary.OpenAddressBook();
                        break;
                    case 3:
                        mylibrary.Display();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Application...");
                        break;
                    case 5:
                        mylibrary.SearchAndFilter();
                        break;
                    case 6:
                        Console.WriteLine("Exiting Application...");
                        break;
                   
                    case 7:
                        Console.WriteLine("Exiting Application...");
                        break;
                    default:
                        Console.WriteLine("Invalid Option!!!");
                        break;
                }
                if (option == 7)
                    break;
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            } while (option != 7);
        }
    }
}
