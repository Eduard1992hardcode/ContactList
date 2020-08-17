using ContactList.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Data
{

    public class ContactService : IContactService
        {

            private readonly ContactListContext _context;

        public ContactService(ContactListContext context)
        {
            _context = context;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            contact.Id = 0;
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteContact(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<Contact> EditContact(Contact contact, long id)
        {
            var contactFromDb = await _context.Contacts.FindAsync(id);

            if (contactFromDb == null)
            {
                return contact;
            }

            contactFromDb.Name = contact.Name;
            contactFromDb.Surname = contact.Surname;
            contactFromDb.Email = contact.Email;
            contactFromDb.Number = contact.Number;
            contactFromDb.TellNumber = contact.TellNumber;

            await _context.SaveChangesAsync();

            return contactFromDb; ;
        }


        public async Task<List<Contact>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(long id)
        {
           return await _context.Contacts.FindAsync(id);
        }

        public bool ContactExists(long id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
    
}
