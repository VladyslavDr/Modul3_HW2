namespace Contacts.Models.Abstractions
{
    public interface IContactModel
    {
        public string FullName { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}