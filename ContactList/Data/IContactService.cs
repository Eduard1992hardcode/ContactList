using ContactList.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Data
{
    public interface IContactService
    {
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContactById(long id);
        Task<Contact> EditContact(Contact contacts, long id);
        Task<Contact> AddContact(Contact contacts);
        Task<bool> DeleteContact(long id);
        bool ContactExists(long id);
    }
}
