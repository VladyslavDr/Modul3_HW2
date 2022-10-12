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
                FirstName = "алиса",
                LastName = "ворон",
                PhoneNumber = "+380664666426"
            };

            var contact2 = new Contact()
            {
                FirstName = "vlad",
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
                FirstName = "89alex",
                PhoneNumber = "+380664666488"
            };

            var contact6 = new Contact()
            {
                FirstName = "tomas",
                PhoneNumber = "+380664666499"
            };
            var contactLog = new ContactList();

            contactLog.Add(contact1);
            contactLog.Add(contact2);
            contactLog.Add(contact2);
            contactLog.Add(contact2);
            contactLog.Add(contact2);
            contactLog.Add(contact3);
            contactLog.Add(contact4);
            contactLog.Add(contact5);
            contactLog.Add(contact6);

            contactLog.Remove(contact1);
            contactLog.Remove(contact5);

            foreach (var item in contactLog)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {item.PhoneNumber}");
            }
        }
    }
}