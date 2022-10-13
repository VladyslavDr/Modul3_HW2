using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Contacts
{
    public class Starter
    {
        public void Run()
        {
            var contact1 = new Contact()
            {
                FirstName = "Євген",
                LastName = "Енеїдович",
                PhoneNumber = "380664666488"
            };

            var contact2 = new Contact()
            {
                FirstName = "Tom",
                PhoneNumber = "380664666455"
            };

            var contactLog = new ContactList();

            contactLog.Add(contact1);
            contactLog.Add(contact2);

            foreach (var item in contactLog)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {item.PhoneNumber}");
            }
        }
    }
}