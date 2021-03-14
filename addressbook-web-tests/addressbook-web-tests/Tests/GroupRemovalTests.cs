using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //prepare
            GroupData newgroup = new GroupData("grouptoremove");
            app.Groups.CreateGroupIfDoesntExists(newgroup);

            //action
            //1. get old list
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //2. remove
            app.Groups.Remove(0);

            //verification
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count); //compare count
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups); //compare value
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
