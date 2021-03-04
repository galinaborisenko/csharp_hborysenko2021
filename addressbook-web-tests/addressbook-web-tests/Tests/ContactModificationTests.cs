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
            ContactData newData = new ContactData("AAFlala", "Llala");
            newData.Middlename = "";

            app.Contacts.Modify(newData);
        }
    }
}
