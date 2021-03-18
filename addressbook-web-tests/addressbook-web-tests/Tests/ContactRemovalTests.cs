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
            ContactData newcontact = new ContactData("test", "test");
            app.Contacts.CreateContactIfDoesntExists(newcontact);

            //action
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            //verification
            //Thread.Sleep(5000);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            //Console.WriteLine(string.Join("\n", oldContacts));
            //Console.WriteLine(string.Join("\n", newContacts));
            Assert.AreEqual(oldContacts.Count, newContacts.Count);  //compare count
            Assert.AreEqual(oldContacts, newContacts); //compare data
            foreach (ContactData group in newContacts)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}
