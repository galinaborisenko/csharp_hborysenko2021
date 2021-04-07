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
            //1. get old list
            List<ContactData> oldContacts = ContactData.GetAll(); //from DB
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

            //verification
            //Thread.Sleep(5000);
            List<ContactData> newContacts = ContactData.GetAll(); //from DB
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);  //compare count
            oldContacts.RemoveAt(0);
            //Console.WriteLine(string.Join("\n", oldContacts));
            //Console.WriteLine(string.Join("\n", newContacts));           
            Assert.AreEqual(oldContacts, newContacts); //compare data
            foreach (ContactData group in newContacts)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}
