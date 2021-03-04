using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

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
            app.Contacts.Remove(1);

            //verification
        }
    }
}
