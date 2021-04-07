using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //prepare
            GroupData newGroup = new GroupData("grouptomodify");
            app.Groups.CreateGroupIfDoesntExists(newGroup);

            List<GroupData> oldGroups = GroupData.GetAll(); //get old list from DB
            GroupData toBeModified = oldGroups[0]; 

            //action
            GroupData newData = new GroupData("1zzz");
            newData.Header = "1tzzzest";
            newData.Footer = "1teszzzt";
            app.Groups.Modify(toBeModified, newData);

            //verification
            List<GroupData> newGroups = GroupData.GetAll(); //get new list from DB
            Assert.AreEqual(oldGroups.Count, newGroups.Count); //compare count
            toBeModified.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data (the old list with the new list)
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                    Assert.AreEqual(newData.Name, group.Name);
            }
        }

        [Test]
        public void GroupModificationTestOnlyName()
        {
            //prepare
            GroupData newGroup = new GroupData("grouptomodify");
            app.Groups.CreateGroupIfDoesntExists(newGroup);

           List<GroupData> oldGroups = GroupData.GetAll();
           GroupData toBeModified = oldGroups[0];

            //action
            GroupData newData = new GroupData("1zzz");
            app.Groups.Modify(toBeModified, newData);

            //verification
            List<GroupData> newGroups = GroupData.GetAll();
            Assert.AreEqual(oldGroups.Count, newGroups.Count); //compare count
            toBeModified.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data (the old list with the new list)
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                    Assert.AreEqual(newData.Name, group.Name);
            }
        }
    }
}
