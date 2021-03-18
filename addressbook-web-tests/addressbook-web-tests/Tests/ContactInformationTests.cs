using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class ContactInformationTests: AuthTestBase
    {
        [Test]
        public void ContactInfoTableAndEditFormTest()
        {
            //action
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromFrom = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromFrom);
            Assert.AreEqual(fromTable.Address, fromFrom.Address);
            Assert.AreEqual(fromTable.AllPhones, fromFrom.AllPhones);
            //Console.WriteLine(fromTable.AllPhones);
            //Console.WriteLine(fromFrom.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromFrom.AllEmails);
        }

        [Test]
        public void ContactInfoTableAndDetailsTest()
        {
            //action
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            //verification
            Assert.AreEqual(fromTable.FirstLastName, fromDetails.FirstLastName);
            Assert.AreEqual(fromTable.ContactInfo, fromDetails.ContactInfo);
        }

    }
}
