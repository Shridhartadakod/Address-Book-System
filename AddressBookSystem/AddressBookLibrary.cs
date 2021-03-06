using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBookLibrary
    {
        private readonly Dictionary<string, AddressBook> library;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookLibrary"/> class.
        /// </summary>
        public AddressBookLibrary()
        {
            library = new Dictionary<string, AddressBook>();
        }

        /// <summary>
        /// Adds an address book to the library.
        /// </summary>
        public void AddAddressBook()
        {
            string name = Userinput.GetName("Enter Name of AddressBook: ");
            if (library.ContainsKey(name) is false && String.IsNullOrEmpty(name) is false)
            {
                library.Add(name, new AddressBook());
                Console.WriteLine("AddressBook Added Successfully");
            }
            else if (String.IsNullOrEmpty(name))
                Console.WriteLine("Invalid name");
            else
                Console.WriteLine("AddressBook with that name already exists");
        }

        /// <summary>
        /// Opens an existing AddressBook with menu option to interact with it
        /// </summary>
        public void OpenAddressBook()
        {
            string name = Userinput.GetName("Enter Name of AddressBook: ");
            if (library.ContainsKey(name))
                AddressBookMenu.List(name, library[name]);
            else
                Console.WriteLine("Addressbook with that name does not exist");
        }

        /// <summary>
        /// Display all Address Books in the library
        /// </summary>
        public void Display()
        {
            Console.WriteLine("List of Address Books:");
            foreach (var name in library.Keys)
                Console.WriteLine(name);
        }

        public void DisplayFilteredList()
        {
            List<Contact> filteredList = LocationFilter();
            foreach (Contact contact in filteredList)
                contact.Display();
        }

        /// <summary>
        /// Filter results based on location
        /// </summary>
        public List<Contact> LocationFilter()
        {
            int option = 0;
            List<Contact> filteredList = new List<Contact>();
            Console.WriteLine("Filter Contact list in full library of AddressBooks:");
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
                    StateFilter(state, filteredList);
                    break;
                case 2:
                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();
                    CityFilter(city, filteredList);
                    break;
                default:
                    Console.WriteLine("Error!!!");
                    break;
            }
            return filteredList;
        }

        /// <summary>
        /// Filter results by city
        /// </summary>
        public void CityFilter(string city, List<Contact> filteredList)
        {
            Dictionary<string, AddressBook>.Enumerator enumerator = library.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.CityFilter(city, filteredList);
            }
        }

        /// <summary>
        /// Filter results by state
        /// </summary>
        public void StateFilter(string State, List<Contact> filteredList)
        {
            Dictionary<string, AddressBook>.Enumerator enumerator = library.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.StateFilter(State, filteredList);
            }
        }

        /// <summary>
        /// Searches in the filtered list
        /// </summary>
        public void SearchAndFilter()
        {
            Console.Write("Enter name of person to search: ");
            string fullName = Console.ReadLine();
            List<Contact> filteredList = LocationFilter();
            var searchResults = filteredList.FindAll(contact => contact.FullName == fullName);
            Console.WriteLine("Filtered Search Results: ");
            foreach (Contact contact in searchResults)
                contact.Display();
        }

        public void DisplayCountByLocation()
        {
            Console.WriteLine("Count of contacts at the library level:");
            var cityWiseCount = GetCityWiseCount();
            var stateWiseCount = GetStateWiseCount();

            Console.WriteLine("\nCity wise count: ");
            foreach (var city in cityWiseCount)
                Console.WriteLine($"City: {city.Key}, No of contacts: {city.Value}");

            Console.WriteLine("\nState wise count: ");
            foreach (var state in stateWiseCount)
                Console.WriteLine($"State: {state.Key}, No of contacts: {state.Value}");
        }

        /// <summary>
        /// Gets the city wise count of contacts.
        /// </summary>
        public Dictionary<string, int> GetCityWiseCount()
        {
            Dictionary<string, int> cityCounts = new Dictionary<string, int>();
            var cityWiseCountCollection = library.Values.Select(x => x.GetCityWiseCount()).ToList();
            foreach (var cityWiseCount in cityWiseCountCollection)
                foreach (var city in cityWiseCount)
                    if (cityCounts.ContainsKey(city.Key))
                        cityCounts[city.Key] += city.Value;
                    else
                        cityCounts.Add(city.Key, city.Value);
            return cityCounts;
        }

        /// <summary>
        /// Gets the state wise count of contacts.
        /// </summary>
        public Dictionary<string, int> GetStateWiseCount()
        {
            Dictionary<string, int> stateCounts = new Dictionary<string, int>();
            var stateWiseCountCollection = library.Values.Select(x => x.GetStateWiseCount()).ToList();
            foreach (var stateWiseCount in stateWiseCountCollection)
                foreach (var state in stateWiseCount)
                    if (stateCounts.ContainsKey(state.Key))
                        stateCounts[state.Key] += state.Value;
                    else
                        stateCounts.Add(state.Key, state.Value);
            return stateCounts;
        }
    }
}
