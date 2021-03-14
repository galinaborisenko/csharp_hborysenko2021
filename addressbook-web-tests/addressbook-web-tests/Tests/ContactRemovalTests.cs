using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //prepare
            ContactData contact = new ContactData("test", "test");
            app.Contacts.CreateContactIfDoesntExists(contact);

            //action
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);
            
            List<ContactData> newContacts = app.Contacts.GetContactList();

            //verification
            oldContacts.RemoveAt(0);
            Console.WriteLine(string.Join("\n", oldContacts));
            Console.WriteLine(string.Join("\n", newContacts));
            Assert.AreEqual(oldContacts, newContacts); //compare data
            //Assert.AreEqual(oldContacts.Count, newContacts.Count);  //compare count
        }
    }
}
