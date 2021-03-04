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
            GroupData newData = new GroupData("1zzz");
            newData.Header = "1tzzzest";
            newData.Footer = "1teszzzt";
            app.Groups.Modify(1, newData);

            //verification
        }

        [Test]
        public void GroupModificationTestOnlyName()
        {
            //prepare
            GroupData group = new GroupData("grouptomodify");
            app.Groups.CreateGroupIfDoesntExists(group);

            //action
            GroupData newData = new GroupData("1zzz");

            //verification
            app.Groups.Modify(1, newData);
        }
    }
}
