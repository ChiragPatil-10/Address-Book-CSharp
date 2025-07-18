using System;

namespace AddressBook
{
    public class AddressBook
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Welcome to Address Book Computation Problem");

            Contact contact = new Contact();

            Console.Write("Enter FirstName: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter LastName: ");
            contact.LastName = Console.ReadLine();

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

            contact.Display();

            Console.WriteLine("\nContact created Successfully");



        }
    }
}