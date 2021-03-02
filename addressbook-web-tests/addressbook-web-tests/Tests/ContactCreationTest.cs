using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
     {       
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("11first", "11last");
            contact.Middlename = "middle";
           
            app.Contacts.Create(contact);
        }
    }
}
