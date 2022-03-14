using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBook
    {
        // class attributes
        private Dictionary<string, Contact> addresses;

        public object UserInput { get; private set; }


        // Default constructor
        public AddressBook()
        {
            addresses = new Dictionary<string, Contact>();
        }

        // Create new contact then add to AddressBook
        public void CreateContact()
        {
            AddContact(new Contact());
        }

        // Add Contact to AddressBook
        public void AddContact(Contact contact)
        {
            string name = contact.GetName();
            if (addresses.ContainsKey(name) is false && String.IsNullOrEmpty(name) is false)
            {
                addresses.Add(name, contact);
                Console.WriteLine("Contact Added Successfully");
            }
            else if (String.IsNullOrEmpty(name))
                Console.WriteLine("Invalid Contac name");
            else
                Console.WriteLine("Contact name already exists");
        }

        // Add Multiple Contacts
        public void AddMultipleContacts()
        {
            int numberOfContacts = Userinput.GetPositiveInt("Enter no of Contacts to add: ");
            for (int i = 0; i < numberOfContacts; i++)
                CreateContact();
        }

        // Allows Editing of contact based on fullname
        public void EditContact()
        {
            Console.Write("Enter Name of contact to edit: ");
            string name = Userinput.ReadString();
            if (addresses.ContainsKey(name))
            {
                Console.WriteLine("\nCurrent info of " + name);
                addresses[name].Display();
                Console.WriteLine("\nEdit info: ");
                Contact contact = new Contact();
                string newName = contact.GetName();
                if (addresses.ContainsKey(newName) is false || newName == name)
                {
                    addresses.Remove(name);
                    addresses[newName] = contact;
                    Console.WriteLine("Updated!!");
                }
                else
                    Console.WriteLine("Contact name already exists. Failed to update changes");
            }
            else
                Console.WriteLine("The contact does not exist");
        }

        // Delete Contact if name matches
        public void DeleteContact()
        {
            Console.Write("Enter Name of contact to delete: ");
            string name = Userinput.ReadString();
            if (addresses.ContainsKey(name))
            {
                addresses.Remove(name);
                Console.WriteLine("Contact removed");
            }
            else
                Console.WriteLine("Contact does not exist");
        }

        // Displays the full AddressBook
        public void Display()
        {
            foreach (var name in addresses.Keys)
                addresses[name].Display();
        }


        public void LookUp(string fullName)
        {
            if (addresses.ContainsKey(fullName))
                addresses[fullName].Display();
            else
                Console.WriteLine("Contact does not exist");
        }

        /// <summary>
        /// Filter results based on location
        /// </summary>
        public void DisplayFilteredList()
        {
            int option = 0;
            List<Contact> filterredList = new List<Contact>();
            Console.WriteLine("Filter Contact list in this AddressBook:");
            Console.WriteLine("1. Filter by state");
            Console.WriteLine("2. Filter by city");
            Console.Write("Option: ");
            do
            {
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Input must be Integer only");
                }
            } while (option != 1 && option != 2);
            switch (option)
            {
                case 1:
                    Console.Write("Enter state: ");
                    string state = Console.ReadLine();
                    Console.WriteLine($"List of contacts in {state}");
                    StateFilter(state, filterredList);
                    break;
                case 2:
                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();
                    Console.WriteLine($"List of contacts in {city}");
                    CityFilter(city, filterredList);
                    break;
                default:
                    Console.WriteLine("Error!!!");
                    break;
            }
        }

        /// <summary>
        /// Filter results by city
        /// </summary>
        public void CityFilter(string city, List<Contact> filteredList)
        {
            Dictionary<string, Contact>.Enumerator enumerator = addresses.GetEnumerator();
            while (enumerator.MoveNext())
                if (enumerator.Current.Value.City == city)
                    filteredList.Add(enumerator.Current.Value);
        }
        // Filter results by state
        
        public void StateFilter(string state, List<Contact> filteredList)
        {
            Dictionary<string, Contact>.Enumerator enumerator = addresses.GetEnumerator();
            while (enumerator.MoveNext())
                if (enumerator.Current.Value.State == state)
                    filteredList.Add(enumerator.Current.Value);
        }
    }
    
}
