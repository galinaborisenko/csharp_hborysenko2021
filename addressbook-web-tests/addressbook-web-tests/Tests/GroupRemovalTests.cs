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
            GroupData group = new GroupData("grouptoremove");
            app.Groups.CreateGroupIfDoesntExists(group);

            //action
            //1. get old list
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //2. remove
            app.Groups.Remove(0);

            //3. get new list
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //verification
            oldGroups.RemoveAt(0); // prepare old list to compare with a new list
            Assert.AreEqual(oldGroups, newGroups); //compare data (the old list with the new list)

        }
    }
}
