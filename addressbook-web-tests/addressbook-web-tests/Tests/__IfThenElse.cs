using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestClass]
    class UnitTest
    {
        

        [TestMethod]
        public void TestMethod1()
        {
            double  sum = 90;
            bool vipClient = true;
            if (sum > 1000 && vipClient) // conditions: ||- or, &&- and
            {
                sum = sum * 0.9;
                System.Console.Out.Write("Sale 10%, sum =" + sum);
            }
            else
            {
                System.Console.Out.Write("No sale, sum =" + sum);
            }
        }

        [TestMethod]
        public void TestMethod2() // else part can be neglected if nothing to do with it
        {
            double sum = 90;
            bool vipClient = true;
            if (sum > 1000 && vipClient)
            {
                sum = sum * 0.9;
                System.Console.Out.Write("Sale 10%, sum =" + sum);
            }
        }
    }
}
