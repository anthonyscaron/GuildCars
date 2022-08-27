using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class ContactRepositoryQA : IContactRepository
    {
        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact {ContactId=1, ContactName="Joe Schmoe", ContactEmail="joeschmoe@test.com", 
                ContactPhone="5551234567", Message="Please call me tomorrow!"},
            new Contact {ContactId=2, ContactName="Judy Rudy", ContactEmail="judyrudy@test.com",
                ContactPhone=null, Message="Hello, I am interested in VIN#: ABCDEFGH000000003. Please contact me."}
        };
        
        public void CreateContact(Contact contact)
        {

            contact.ContactId = _contacts.Max(m => m.ContactId) + 1;
            _contacts.Add(contact);
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }
    }
}
