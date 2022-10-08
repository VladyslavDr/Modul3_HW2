using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Contacts.Services;
using Contacts.Models;

namespace Contacts
{
    public class Starter
    {
        private CultureInfo _cultureUS = new CultureInfo("en-US");

        private CultureInfo _cultureRU = new CultureInfo("ru-RU");

        public void Run()
        {
            var contact1 = new ContactModel()
            {
                FirstName = "Vlad",
                LastName = "Dryshliak",
                PhoneNumber = "+380664666426"
            };

            var contact2 = new ContactModel()
            {
                FirstName = "Oleg",
                PhoneNumber = "+380668596428"
            };

            var contact3 = new ContactModel()
            {
                PhoneNumber = "+380993221712"
            };

            var contact4 = new ContactModel()
            {
                FirstName = "Vlad",
                LastName = "Dryshliak",
                PhoneNumber = "+380664666426"
            };

            var contact5 = new ContactModel()
            {
                LastName = "Шишов",
                PhoneNumber = "+380958787933"
            };

            var contact6 = new ContactModel()
            {
                FirstName = "6300",
                PhoneNumber = "+380995886300"
            };

            var contactLogService = ContactLogService<ContactModel>.GetInstance(_cultureUS);

            var culture = new CultureInfo("test");
            if (culture.Name.Equals(_cultureUS.Name))
            {
                Console.WriteLine("true");
            }

            // contactLogService.Add(contact1);
        }
    }
}
