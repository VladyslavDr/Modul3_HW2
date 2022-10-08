using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models.Abstractions;

namespace Contacts
{
    public class ContactLogModel<T> : IContactLogModel<T>
        where T : IContactModel
    {
        public List<List<T>> Contacts { get; set; }
        public List<T> Default { get; set; }
        public List<T> Digitals { get; set; }
        public List<T> Others { get; set; }
    }
}
