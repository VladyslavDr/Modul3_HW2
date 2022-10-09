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
        private ContactLogModel<T> _contactLog;
        private Alphabet _alphabetUS = new Alphabet("alphabetUS.json");
        private Alphabet _alphabetUK = new Alphabet("alphabetUA.json");

        private ContactLogService()
        {
            _contactLog = new ContactLogModel<T>();
        }

        public static ContactLogService<T> GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ContactLogService<T>();
            }

            return _instance;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetGenericEnumerator();
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

            if (CultureInfo.CurrentUICulture.Name.Equals("en-US"))
            {
                var isLatinLetter = false;

                foreach (var letterFullName in contact.FullName)
                {
                    foreach (var letterAlphabet in _alphabetUS.GetAlphabet)
                    {
                        if (letterAlphabet.Equals(letterFullName))
                        {
                            isLatinLetter = true;
                        }
                    }
                }

                if (isLatinLetter)
                {
                    _contactLog.Default.Add(contact);
                }
                else
                {
                    _contactLog.Others.Add(contact);
                }
            }

            if (CultureInfo.CurrentUICulture.Name.Equals("uk-UA"))
            {
                var isCyrillicLetter = false;

                foreach (var letterFullName in contact.FullName)
                {
                    foreach (var letterAlphabet in _alphabetUK.GetAlphabet)
                    {
                        if (letterAlphabet.Equals(letterFullName))
                        {
                            isCyrillicLetter = true;
                        }
                    }
                }

                if (isCyrillicLetter)
                {
                    _contactLog.Default.Add(contact);
                }
                else
                {
                    _contactLog.Others.Add(contact);
                }
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
            return GetGenericEnumerator();
        }

        private IEnumerator<T> GetGenericEnumerator()
        {
            foreach (var contacts in _contactLog.Contacts)
            {
                foreach (var contact in contacts)
                {
                    yield return contact;
                }
            }
        }
    }
}
