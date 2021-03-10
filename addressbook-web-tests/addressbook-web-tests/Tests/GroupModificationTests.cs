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
            GroupData group = new GroupData("grouptomodify");
            app.Groups.CreateGroupIfDoesntExists(group);

            //action
            //1. get old list
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //2. modify group
            GroupData newData = new GroupData("1zzz");
            newData.Header = "1tzzzest";
            newData.Footer = "1teszzzt";
            app.Groups.Modify(0, newData);

            //3. get new list
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //verification
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data (the old list with the new list)
        }

        [Test]
        public void GroupModificationTestOnlyName()
        {
            //prepare
            GroupData group = new GroupData("grouptomodify");
            app.Groups.CreateGroupIfDoesntExists(group);

            //action
            //1. get old list
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //2. modify group
            GroupData newData = new GroupData("1zzz");
            app.Groups.Modify(0, newData);

            //3. get new list
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //verification
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //compare data (the old list with the new list)
        }
    }
}
