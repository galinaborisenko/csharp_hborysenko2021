using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
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
        
    
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {          
            //action
            //1. get old list
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //2. create 
            app.Groups.Create(group);

            //verification
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount()); //compare count
            List<GroupData> newGroups = app.Groups.GetGroupList(); //get new list    
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data
            Assert.AreEqual(oldGroups.Count, newGroups.Count);  //compare count
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
