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
            Login(new AccountData("admin","secret"));
            OpenGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("test");
            group.Header = "ddd";
            group.Footer = "fff";
            FillGroupForm(group);
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

        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"group_name\"]")).Click();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"group_name\"]")).Clear();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"group_name\"]")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_header\"]")).Click();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_header\"]")).Clear();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_header\"]")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_footer\"]")).Click();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_footer\"]")).Clear();
            driver.FindElement(By.CssSelector("form[method=\"post\"]>textarea[name=\"group_footer\"]")).SendKeys(group.Footer);
        }

        private void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"get\"]>input[name=\"new\"]")).Click();
        }

        private void OpenGroupsPage()
        {
            driver.FindElement(By.CssSelector(".admin>a[href*=\"group\"]")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).SendKeys(account.Password);
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
