using System;


namespace AddressBook
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address {  get; set; }
        public string City { get; set; }
        public string State {  get; set; }
        public string Zip {  get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            Console.WriteLine("\n---  Contact Details ---");
            Console.WriteLine($"Name         : {FirstName} {LastName}");
            Console.WriteLine($"Address      : {Address}, {City}, {State} - {Zip}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
            Console.WriteLine($"Email        : {Email}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contact))
                return false;

            Contact other = (Contact)obj;
            return this.FirstName.Equals(other.FirstName, StringComparison.OrdinalIgnoreCase)
                && this.LastName.Equals(other.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).ToLower().GetHashCode();
        }

    }
}
