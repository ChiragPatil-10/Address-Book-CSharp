using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class AddressBookSystem
    {
        private Dictionary<string, AddressBook> addressBooks;

        public AddressBookSystem()
        {
            addressBooks = new Dictionary<string, AddressBook>();
        }

        public void AddAddressBook()
        {
            Console.Write("\nEnter a unique name for the new Address Book: ");
            string bookName = Console.ReadLine().Trim();

            if (addressBooks.ContainsKey(bookName))
            {
                Console.WriteLine($"Address Book '{bookName}' already exists. Please choose a different name.");
                return;
            }

            AddressBook newBook = new AddressBook();
            addressBooks.Add(bookName, newBook);

            Console.WriteLine($"Address Book '{bookName}' created successfully!");

            Console.Write("Do you want to add contacts to this address book now? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();

            if (response == "yes" || response == "y")
            {
                newBook.AddMultipleContacts();
            }
        }

        public void DisplayAllAddressBooks()
        {
            Console.WriteLine("\n List of all Address Books:");
            foreach (var name in addressBooks.Keys)
            {
                Console.WriteLine($"- {name}");
            }
        }
    }
}
