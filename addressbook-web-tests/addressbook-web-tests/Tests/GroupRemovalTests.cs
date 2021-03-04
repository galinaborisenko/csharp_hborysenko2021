using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Groups.Remove(1);

            //verification

        }
    }
}
