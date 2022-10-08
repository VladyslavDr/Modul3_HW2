using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Contacts.Services.Abstractions;
using Contacts.Models.Abstractions;

namespace Contacts.Services
{
    public class ContactLogService<T> : IEnumerable<T>, IContactLogService<T>
        where T : IContactModel
    {
        private static ContactLogService<T> _instance;
        private static CultureInfo _myCulture;
        private ContactLogModel<T> _contactLog;

        private ContactLogService()
        {
            _contactLog = new ContactLogModel<T>();
            _myCulture = new CultureInfo("en-US");
        }

        public static ContactLogService<T> GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ContactLogService<T>();
            }

            return _instance;
        }

        public static ContactLogService<T> GetInstance(CultureInfo culture)
        {
            _myCulture = culture;
            return GetInstance();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Add(T contact)
        {
            var isThereContact = CheckForContactInTheContactLog(contact);

            if (isThereContact)
            {
                return false;
            }

            var isNumber = int.TryParse(contact.FullName[0].ToString(), out var res);

            if (isNumber)
            {
                _contactLog.Digitals.Add(contact);
            }

            return true;
        }

        public bool CheckForContactInTheContactLog(T contact)
        {
            foreach (var contacts in _contactLog.Contacts)
            {
                foreach (var item in contacts)
                {
                    if (item.PhoneNumber.Equals(contact.PhoneNumber))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
