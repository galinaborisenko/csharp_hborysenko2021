using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
     {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(100), GenerateRandomString(100))
                {
                    Middlename = GenerateRandomString(100)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }


        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            //action
            //1. get old list
            List<ContactData> oldContacts = ContactData.GetAll();
            
            //2. create 
            app.Contacts.Create(contact);


            //verification  
            List<ContactData> newContacts = ContactData.GetAll();         
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Console.WriteLine(string.Join("\n", oldContacts));           
            Console.WriteLine(string.Join("\n", newContacts));
            Assert.AreEqual(oldContacts, newContacts); //compare data
            Assert.AreEqual(oldContacts.Count, newContacts.Count);  //compare count
        }

        /*
         [Test]
        public void ContactCreationTest()
        {
            //preparation
            ContactData contact = new ContactData("Oleh", "Bory");
            contact.Middlename = "middle";

            //action
            //1. get old list
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            
            //2. create 
            app.Contacts.Create(contact);


            //verification  
            List<ContactData> newContacts = app.Contacts.GetContactList();         
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Console.WriteLine(string.Join("\n", oldContacts));           
            Console.WriteLine(string.Join("\n", newContacts));
            Assert.AreEqual(oldContacts, newContacts); //compare data
            Assert.AreEqual(oldContacts.Count, newContacts.Count);  //compare count
        }     
         */
    }
}
