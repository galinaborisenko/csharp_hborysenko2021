using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
     {       
        [Test]
        public void ContactCreationTest()
        {
            //preparation
            ContactData contact = new ContactData("Mary", "Lee");
            contact.Middlename = "middle";

            //action
            //1. get old list
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            //2. create 
            app.Contacts.Create(contact);
            //3. get new list 
            List<ContactData> newContacts = app.Contacts.GetContactList();

            //verification  
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts); //compare data
            Assert.AreEqual(oldContacts.Count, newContacts.Count);  //compare count
        }
    }
}
