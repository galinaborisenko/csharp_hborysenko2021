using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login("admin", "secret");
            OpenGroupsPage();
            InitGroupCreation();
            FillGroupForm("new group", "test", "test");
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.CssSelector(".header a[onclick*=\"logout\"]")).Click();
        }

        private void ReturnToGroupsPage()
        {
            driver.FindElement(By.CssSelector("div.msgbox a[href*=\"group\"]")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[type=\"submit\"]")).Click();
        }

        private void FillGroupForm(string name, string header, string footer)
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"group_name\"]")).Click();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"group_name\"]")).Clear();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"group_name\"]")).SendKeys(name);
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_header\"]")).Click();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_header\"]")).Clear();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_header\"]")).SendKeys(header);
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_footer\"]")).Click();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_footer\"]")).Clear();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_footer\"]")).SendKeys(footer);
        }

        private void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"get\"]>input[name=\"new\"]")).Click();
        }

        private void OpenGroupsPage()
        {
            driver.FindElement(By.CssSelector(".admin>a[href*=\"group\"]")).Click();
        }

        private void Login(string userName, string password)
        {
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).SendKeys(userName);
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).SendKeys(password);
            driver.FindElement(By.CssSelector("#LoginForm input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
