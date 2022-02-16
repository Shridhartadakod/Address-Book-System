﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBook
    {
        private Dictionary<string, Contact> addresses;


        // Default constructor
        public AddressBook()
        {
            addresses = new Dictionary<string, Contact>();
        }

        // Create new contact then add to AddressBook
        public void CreateContact()
        {
            Contact contact = new Contact();
            AddContact(contact);
        }

        // Add Contact to AddressBook
        public void AddContact(Contact contact)
        {
            string name = contact.GetName();
            if (addresses.ContainsKey(name) is false)
                addresses.Add(name, contact);
            else
                Console.WriteLine("Contact name already exists");
        }

        // Allows Editing of contact based on fullname
        public void EditContact()
        {
            Console.Write("Enter Name of contact to edit: ");
            string name = Console.ReadLine();
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
        public void Display()
        {
            foreach (var name in addresses.Keys)
                addresses[name].Display();
        }
    }
    
}