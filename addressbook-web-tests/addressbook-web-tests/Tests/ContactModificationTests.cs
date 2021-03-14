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

            //action
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newData = new ContactData("Halyna", "Borysenko");
            newData.Middlename = "";
            app.Contacts.Modify(newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            //verification  
            oldContacts[0].Firstname=newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            //Console.WriteLine(string.Join("\n", oldContacts));
            //Console.WriteLine(string.Join("\n", newContacts));
            Assert.AreEqual(oldContacts, newContacts); //compare data
            Assert.AreEqual(oldContacts.Count, newContacts.Count);  //compare count
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContacts[0].Id)
                    Assert.AreEqual(newData.Lastname + newData.Firstname, contact.Lastname + contact.Firstname);
            }
        }
    }
}
