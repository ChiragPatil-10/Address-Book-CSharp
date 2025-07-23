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