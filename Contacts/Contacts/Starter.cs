using System;
using System.Collections.Generic;

namespace Contacts
{
    public class Starter
    {
        public void Run()
        {
            var contact1 = new Contact()
            {
                FirstName = "Вася",
                LastName = "Пупкин",
                PhoneNumber = "380664666488"
            };

            var contact2 = new Contact()
            {
                FirstName = "Mask",
                PhoneNumber = "+380664666425"
            };

            var contact3 = new Contact()
            {
                FirstName = "alex",
                PhoneNumber = "+380664666411"
            };

            var contact4 = new Contact()
            {
                FirstName = "5alex",
                PhoneNumber = "+380664666470"
            };

            var contact5 = new Contact()
            {
                FirstName = "~томlex",
                PhoneNumber = "+380664666470"
            };
            var contactLog = new ContactList();

            contactLog.Add(contact1);
            contactLog.Add(contact1);

            contactLog.Add(contact2);

            contactLog.Add(contact3);
            contactLog.Add(contact3);
            contactLog.Add(contact3);
            contactLog.Add(contact3);

            contactLog.Add(contact4);
            contactLog.Add(contact5);

            foreach (var item in contactLog)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {item.PhoneNumber}");
            }
        }
    }
}