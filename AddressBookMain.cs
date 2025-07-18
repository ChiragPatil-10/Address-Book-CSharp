using System;

namespace AddressBook
{
    public class AddressBookMain
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Welcome to Address Book Computation Problem");
            
            AddressBook addressbook = new AddressBook();

            addressbook.AddContact();

            addressbook.EditContact();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}