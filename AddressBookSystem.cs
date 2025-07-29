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

        public void SearchPersonByCityOrState()
        {
            Console.Write("Enter City or State to search for: ");
            string input = Console.ReadLine();

            Console.WriteLine($"\n Searching for contacts in '{input}'...\n");

            bool found = false;

            foreach (var kvp in addressBooks)
            {
                string bookName = kvp.Key;
                AddressBook book = kvp.Value;

                var matchingContacts = book.GetContactsByCityOrState(input);

                if (matchingContacts.Count > 0)
                {
                    found = true;
                    Console.WriteLine($"\n Address Book: {bookName}");

                    foreach (var contact in matchingContacts)
                    {
                        contact.Display();
                        Console.WriteLine();
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No contacts found in the given city or state.");
            }
        }
    }
}
