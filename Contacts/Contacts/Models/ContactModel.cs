using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models.Abstractions;

namespace Contacts.Models
{
    public class ContactModel : IContactModel
    {
        public string FullName
        {
            get
            {
                if (FirstName == default(string) && LastName == default(string))
                {
                    return PhoneNumber;
                }
                else
                {
                    return (FirstName + LastName).ToLower();
                }
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
