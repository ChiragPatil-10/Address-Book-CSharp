using System;

namespace AddressBook
{
    public class AddressBookMain
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Welcome to Address Book Computation Problem");

            AddressBookSystem system = new AddressBookSystem();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nAddress Book Menu:");
                Console.WriteLine("1. Add New Address Book");
                Console.WriteLine("2. Show All Address Book Names");
                Console.WriteLine("3. Search Person by City or State");
                Console.WriteLine("4. View Persons by City or State");
                Console.WriteLine("5. Count Contacts by City or State");
                Console.WriteLine("6. Sort Contacts in Address Book by Name");
                Console.WriteLine("7. Sort Contacts in Address Book by City, State, or Zip");
                Console.WriteLine("0. Exit");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        system.AddAddressBook();
                        break;
                    case "2":
                        system.DisplayAllAddressBooks();
                        break;
                    case "3":
                        system.SearchPersonByCityOrState();
                        break;
                    case "4":
                        system.ViewPersonsByCityOrState();
                        break;
                    case "5":
                        system.CountContactsByCityOrState();
                        break;
                    case "6":
                        system.SortAddressBookByName();
                        break;
                    case "7":
                        system.SortAddressBookByCityStateOrZip();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            Console.WriteLine("Exiting...");
        }
    }
}