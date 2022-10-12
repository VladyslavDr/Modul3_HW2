using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Contacts
{
    public class ContactList : IEnumerable
    {
        private List<List<IContact>> _contacts;
        private List<IContact> _default;
        private List<IContact> _digitals;
        private List<IContact> _sharp;
        private Alphabet _alphabetUS = new Alphabet("alphabetUS.json");
        private Alphabet _alphabetUK = new Alphabet("alphabetUK.json");
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
            string str = string.Empty;

            if (int.TryParse(contact.FullName[0].ToString(), out var res))
            {
                Digitals.Add(contact);
                Digitals.Sort(new ContactFullNameComparer());
                return true;
            }

            if (CultureInfo.CurrentUICulture.Name.Equals("en-US"))
            {
                for (int i = 0; i < contact.FullName.Length; i++)
                {
                    foreach (var letter in _alphabetUS.GetAlphabet)
                    {
                        if (contact.FullName[i].Equals(letter))
                        {
                            str += contact.FullName[i];
                        }
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

                return true;
            }

            if (CultureInfo.CurrentUICulture.Name.Equals("uk-UA"))
            {
                for (int i = 0; i < contact.FullName.Length; i++)
                {
                    foreach (var letter in _alphabetUK.GetAlphabet)
                    {
                        if (contact.FullName[i].Equals(letter))
                        {
                            str += contact.FullName[i];
                        }
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

                return true;
            }

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

        public IEnumerator<IContact> GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        private IEnumerator<IContact> GetGenericEnumerator()
        {
            foreach (var contacts in Contacts)
            {
                foreach (var contact in contacts)
                {
                    yield return contact;
                }
            }
        }
    }
}