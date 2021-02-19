using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
     {       
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenEditPage();
            ContactData contact = new ContactData("first", "last");
            contact.Middlename = "middle";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToEditPage();
            Logout();
        }
    }
}
