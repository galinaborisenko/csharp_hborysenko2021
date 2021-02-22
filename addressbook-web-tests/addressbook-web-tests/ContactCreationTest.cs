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
            navigationHelper.GoToHomePage();
            loginLogoutHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactCreation();
            ContactData contact = new ContactData("first", "last");
            contact.Middlename = "middle";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToEditPage();
            loginLogoutHelper.Logout();
        }
    }
}
