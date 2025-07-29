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

        public void ViewPersonsByCityOrState()
        {
            Dictionary<string, List<Contact>> cityMap = new Dictionary<string, List<Contact>>();
            Dictionary<string, List<Contact>> stateMap = new Dictionary<string, List<Contact>>();

            // Collecting all contacts from all address books
            foreach (var book in addressBooks.Values)
            {
                List<Contact> contacts = book.GetContacts();

                foreach (Contact c in contacts)
                {
                    // Add to city map
                    if (!cityMap.ContainsKey(c.City))
                    {
                        cityMap[c.City] = new List<Contact>();
                    }
                    cityMap[c.City].Add(c);

                    // Add to state map
                    if (!stateMap.ContainsKey(c.State))
                    {
                        stateMap[c.State] = new List<Contact>();
                    }
                    stateMap[c.State].Add(c);
                }
            }

            Console.Write("View persons by (city/state): ");
            string choice = Console.ReadLine().Trim().ToLower();

            if (choice == "city")
            {
                Console.Write("Enter city name: ");
                string city = Console.ReadLine();
                if (cityMap.ContainsKey(city))
                {
                    Console.WriteLine($"\nPeople in {city}:");
                    foreach (var person in cityMap[city])
                    {
                        person.Display();
                    }
                }
                else
                {
                    Console.WriteLine("No persons found in that city.");
                }
            }
            else if (choice == "state")
            {
                Console.Write("Enter state name: ");
                string state = Console.ReadLine();
                if (stateMap.ContainsKey(state))
                {
                    Console.WriteLine($"\nPeople in {state}:");
                    foreach (var person in stateMap[state])
                    {
                        person.Display();
                    }
                }
                else
                {
                    Console.WriteLine("No persons found in that state.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public void CountContactsByCityOrState()
        {
            Dictionary<string, int> cityCounts = new Dictionary<string, int>();
            Dictionary<string, int> stateCounts = new Dictionary<string, int>();

            foreach (var book in addressBooks.Values)
            {
                List<Contact> contacts = book.GetContacts();

                foreach (Contact c in contacts)
                {
                    if (cityCounts.ContainsKey(c.City))
                        cityCounts[c.City]++;
                    else
                        cityCounts[c.City] = 1;

                    if (stateCounts.ContainsKey(c.State))
                        stateCounts[c.State]++;
                    else
                        stateCounts[c.State] = 1;
                }
            }

            Console.WriteLine("\nCount of Contacts by City:");
            foreach (var entry in cityCounts)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value} person(s)");
            }

            Console.WriteLine("\nCount of Contacts by State:");
            foreach (var entry in stateCounts)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value} person(s)");
            }
        }

        public void SortAddressBookByName()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Address Books Available.");
                return;
            }

            Console.Write("Enter the name of the Address Book to sort: ");
            string bookName = Console.ReadLine();

            if (addressBooks.ContainsKey(bookName))
            {
                addressBooks[bookName].SortContactsByName();
            }
            else
            {
                Console.WriteLine("Address Book not found.");
            }
        }

    }
}
