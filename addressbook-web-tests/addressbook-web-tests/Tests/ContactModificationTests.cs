using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            //prepare
            ContactData newcontact = new ContactData("test", "test");
            app.Contacts.CreateContactIfDoesntExists(newcontact);

   
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];

            //action
            ContactData newData = new ContactData("Hal", "Bor");
            newData.Middlename = "";
            app.Contacts.Modify(toBeModified, newData) ;

            //verification  
            List<ContactData> newContacts = ContactData.GetAll();
            Assert.AreEqual(oldContacts.Count, newContacts.Count); //compare count
            toBeModified.Firstname=newData.Firstname;
            toBeModified.Lastname = newData.Lastname;
            toBeModified.Middlename = newData.Middlename;
            oldContacts.Sort();
            newContacts.Sort();
            Console.WriteLine(string.Join("\n", oldContacts));
            Console.WriteLine(string.Join("\n", newContacts));
            Assert.AreEqual(oldContacts, newContacts); //compare data
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                    Assert.AreEqual(newData.Lastname + newData.Firstname, contact.Lastname + contact.Firstname);
            }
        }
    }
}
