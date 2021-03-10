using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestClass]
    public class __ForWhile
    {
        [TestMethod]
        public void TestMethod1()
        {
            //example 1
            string[] s = new string[] {"I", "want", "to", "sleep"};
            for (int i = 0; i<s.Length; i = i+1)
            {
                System.Console.Out.Write(s[i] + "\n");
            }

            //example 2
            string[] ss = new string[] { "I", "want", "to", "sleep" };
            foreach (string element in ss)
            {
                System.Console.Out.Write(element + "\n");
            }

            //example 3
            IWebDriver driver = null;
            int attempt = 0;
           // while (driver.FindElement(By.Id("test")).Count == 0 && attempt < 60) 
            {
                System.Threading.Thread.Sleep(1000); // wait 1 sec
                attempt = attempt++;// the same as attempt +1
            }

            //example 4
           // IWebDriver driver = null;
           // int attempt = 0;
         //   do
          //  {
          //      System.Threading.Thread.Sleep(1000); // wait 1 sec
          //      attempt = attempt++;// the same as attempt +1
          //  }

           // while (driver.FindElement(By.Id("test")).Count == 0 && attempt < 60);
            

        }
    }
}
