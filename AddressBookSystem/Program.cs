using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to address book system");
            AddressBook myContacts = new AddressBook();
            myContacts.CreateContact();
            myContacts.Display();
            MenuList.List();

            Console.ReadKey();
        }
    }
}
