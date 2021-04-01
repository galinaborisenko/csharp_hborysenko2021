using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {

        [Test]
        public void TestAddingContactToGroup() 
        {
            //from DB
            GroupData group = GroupData.GetAll()[0]; //select group with index 0 = from DB
            List<ContactData> oldList = group.GetContacts(); //list of contacts in group [0]
            ContactData contact = ContactData.GetAll().Except(oldList).First(); //1) full list 2)except those group [0] 3)select the fisrt

            //actions on UI
            app.Contacts.AddContactToGroup(contact, group);


            //verification
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }


    }
}
