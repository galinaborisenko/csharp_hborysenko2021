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
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml")); //приведение типа
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            //action
            //1. get old list
            List<GroupData> oldGroups = GroupData.GetAll(); //get from DB

            //2. create 
            app.Groups.Create(group);

            //verification
            List<GroupData> newGroups = GroupData.GetAll(); //get new list    
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data
            Assert.AreEqual(oldGroups.Count, newGroups.Count);  //compare count
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }

        [Test]
        public void TestDBConnectivity1()
        {
            foreach (ContactData contact in GroupData.GetAll()[0].GetContacts()){
                System.Console.Out.WriteLine(contact);
            }
        }

        [Test]
        public void TestDBConnectivity2()
        {
            foreach (ContactData contact in ContactData.GetAll()){
                System.Console.Out.WriteLine(contact.Deprecated);
            }
        }


        /*[Test]
        public void EmptyGroupCreationTest()
        {
            //preparation
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            //action
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            //verification
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //compare count
            List<GroupData> newGroups = app.Groups.GetGroupList(); //get new list    
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data
            Assert.AreEqual(oldGroups.Count, newGroups.Count);  //compare count
        }

       
        [Test]
        public void BadNameGroupCreationTest()
        {
            //preparation
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            //action
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            //verification
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //compare count
            List<GroupData> newGroups = app.Groups.GetGroupList(); //get new list    
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data
            Assert.AreEqual(oldGroups.Count, newGroups.Count);  //compare count
        }
       */

    }
}
