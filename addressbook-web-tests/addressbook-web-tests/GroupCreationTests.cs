using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            OpenGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("test");
            group.Header = "ddd";
            group.Footer = "fff";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }
    }
}
