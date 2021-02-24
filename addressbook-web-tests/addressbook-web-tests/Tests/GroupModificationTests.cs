using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("1zzz");
            newData.Header = "1tzzzest";
            newData.Footer = "1teszzzt";

            app.Groups.Modify(1, newData);
        }
    }
}
