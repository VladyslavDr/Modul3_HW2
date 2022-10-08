using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Models.Abstractions
{
    public interface IContactLogModel<T>
    {
        public List<List<T>> Contacts { get; set; }
        public List<T> Default { get; set; }
        public List<T> Digitals { get; set; }
        public List<T> Others { get; set; }
    }
}
