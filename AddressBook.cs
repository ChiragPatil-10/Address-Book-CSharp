﻿using System;
using System.Collections.Generic;


namespace AddressBook
{
    public class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }

        public void AddContact()
        {
            Contact contact = new Contact();

            Console.WriteLine("\n--- Enter new Contact Details ---");
            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter LastName: ");
            contact.LastName = Console.ReadLine();

            if (contacts.Contains(contact))
            {
                Console.WriteLine("\nThis contact already exists in the address book. Duplicate not allowed.");
                return;
            }

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City: ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State: ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip: ");
            contact.Zip = Console.ReadLine();

            Console.Write("Enter PhoneNumber: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();

            contacts.Add(contact);

            Console.WriteLine("\n Contact added successfully!!");
            contact.Display();
        }

        public void EditContact()
        {
            Console.WriteLine("\nEnter the first name of the contact to edit: ");
            string nameToEdit = Console.ReadLine();

            Contact contact = contacts.Find(c => c.FirstName.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase));

            if(contact != null)
            {
                Console.WriteLine("\nContact found! Enter new details:");
                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();

                Console.Write("Address: ");
                contact.Address = Console.ReadLine();

                Console.Write("City: ");
                contact.City = Console.ReadLine();

                Console.Write("State: ");
                contact.State = Console.ReadLine();

                Console.Write("Zip Code: ");
                contact.Zip = Console.ReadLine();

                Console.Write("Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();

                Console.Write("Email: ");
                contact.Email = Console.ReadLine();

                Console.WriteLine("\n Contact updated successfully!");
                contact.Display();
            } else
            {
                Console.WriteLine("\n Contact not found with that first name.");
            }

        }

        public void DeleteContact()
        {
            Console.Write("\nEnter the first name of the contact to delete: ");
            string name = Console.ReadLine();

            Contact contactToRemove = contacts.FirstOrDefault(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if(contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("\n Contact deleted successfully.");
            } else
            {
                Console.WriteLine("Contact not found with the given name.");
            }
        }

        public void AddMultipleContacts()
        {
            bool addMore = true;


            while (addMore)

            {
                AddContact();

                Console.Write("\n Do you want to add another contact? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();

                if (response != "yes" && response != "y")

                {
                    addMore = false;
                }
            }
        }
    }
}
