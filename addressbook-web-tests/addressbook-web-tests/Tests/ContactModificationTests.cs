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
            ContactData contact = new ContactData("test", "test");
            app.Contacts.CreateContactIfDoesntExists(contact);

            //action
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newData = new ContactData("AAFlala", "Llala");
            newData.Middlename = "";
            app.Contacts.Modify(newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            //verification  
            oldContacts[0].Firstname=newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
           // Assert.AreEqual(oldContacts, newContacts); //compare data
            Assert.AreEqual(oldContacts.Count, newContacts.Count);  //compare count
        }
    }
}
