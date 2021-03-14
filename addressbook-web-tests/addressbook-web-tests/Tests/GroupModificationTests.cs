using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //prepare
            GroupData newgroup = new GroupData("grouptomodify");
            app.Groups.CreateGroupIfDoesntExists(newgroup);


            //action
            //1. get old list
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            //GroupData oldData = oldGroups[0];

            //2. modify group
            GroupData newData = new GroupData("1zzz");
            newData.Header = "1tzzzest";
            newData.Footer = "1teszzzt";
            app.Groups.Modify(0, newData);

            //verification
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //compare count
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data (the old list with the new list)

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldGroups[0].Id)
                    Assert.AreEqual(newData.Name, group.Name);
            }
        }

        [Test]
        public void GroupModificationTestOnlyName()
        {
            //prepare
            GroupData newgroup = new GroupData("grouptomodify");
            app.Groups.CreateGroupIfDoesntExists(newgroup);

            //action
            //1. get old list
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            //2. modify group
            GroupData newData = new GroupData("1zzz");
            app.Groups.Modify(0, newData);

            //verification
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //compare count
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data (the old list with the new list)

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldGroups[0].Id)
                Assert.AreEqual(newData.Name, group.Name);
            }
        }
    }
}
