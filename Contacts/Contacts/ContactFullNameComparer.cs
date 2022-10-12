using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public class ContactFullNameComparer : IComparer<IContact>
    {
        public int Compare(IContact contact1, IContact contact2)
        {
            if (contact1 == null || contact2 == null)
            {
                return 0;
            }

            return contact1.FullName.CompareTo(contact2.FullName);
        }
    }
}
