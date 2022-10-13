using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Contacts
{
    public class ContactList : IEnumerable
    {
        private List<List<IContact>> _contacts;
        private List<IContact> _default;
        private List<IContact> _digitals;
        private List<IContact> _sharp;
        private Regular _regularUA = new Regular("RegularUA.json");
        private Regular _regularUS = new Regular("RegularUS.json");

        public ContactList()
        {
            _contacts = new List<List<IContact>>();
            _default = new List<IContact>();
            _digitals = new List<IContact>();
            _sharp = new List<IContact>();

            Contacts.Add(Default);
            Contacts.Add(Digitals);
            Contacts.Add(Sharp);
        }

        private List<List<IContact>> Contacts => _contacts;
        private List<IContact> Default => _default;
        private List<IContact> Digitals => _digitals;
        private List<IContact> Sharp => _sharp;

        public bool Add(IContact contact)
        {
            if (CheckForContactInTheContactLog(contact))
            {
                return false;
            }

            if (int.TryParse(contact.FullName[0].ToString(), out var res))
            {
                Digitals.Add(contact);
                Digitals.Sort(new ContactFullNameComparer());
                return true;
            }

            if (CultureInfo.CurrentUICulture.Name.Equals("uk-UA"))
            {
                AddToAppropriateList(_regularUA, contact);
                return true;
            }

            AddToAppropriateList(_regularUS, contact);
            return true;
        }

        public bool Remove(IContact contact)
        {
            foreach (var item in Default)
            {
                if (item.FullName.Equals(contact.FullName))
                {
                    Default.Remove(contact);
                    return true;
                }
            }

            foreach (var item in Digitals)
            {
                if (item.FullName.Equals(contact.FullName))
                {
                    Digitals.Remove(contact);
                    return true;
                }
            }

            foreach (var item in Sharp)
            {
                if (item.FullName.Equals(contact.FullName))
                {
                    Sharp.Remove(contact);
                    return true;
                }
            }

            return false;
        }

        public bool CheckForContactInTheContactLog(IContact contact)
        {
            foreach (var groups in Contacts)
            {
                foreach (var item in groups)
                {
                    if (item.PhoneNumber.Equals(contact.PhoneNumber))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public IEnumerator<IContact> GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        private void AddToAppropriateList(Regular regular, IContact contact)
        {
            string str = string.Empty;

            Regex regex = new Regex(regular.GetRegular);
            MatchCollection matches = regex.Matches(contact.FullName);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    str += match.Value;
                }
            }

            if (contact.FullName.Equals(str))
            {
                Default.Add(contact);
                Default.Sort(new ContactFullNameComparer());
            }
            else
            {
                Sharp.Add(contact);
                Sharp.Sort(new ContactFullNameComparer());
            }
        }

        private IEnumerator<IContact> GetGenericEnumerator()
        {
            Console.WriteLine("default:");
            foreach (var contact in Default)
            {
                yield return contact;
            }

            Console.WriteLine("0-9:");
            foreach (var contact in Digitals)
            {
                yield return contact;
            }

            Console.WriteLine("#:");
            foreach (var contact in Sharp)
            {
                yield return contact;
            }
        }
    }
}