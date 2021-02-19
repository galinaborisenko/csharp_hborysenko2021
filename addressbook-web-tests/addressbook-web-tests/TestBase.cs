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
    public class TestBase 
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
       
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

        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        protected void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("#LoginForm input[type=\"submit\"]")).Click();
        }
        protected void Logout()
        {
            driver.FindElement(By.CssSelector(".header a[onclick*=\"logout\"]")).Click();
        }

        protected void OpenGroupsPage()
        {
            driver.FindElement(By.CssSelector(".admin>a[href*=\"group\"]")).Click();
        }

        protected void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void OpenEditPage()
        {
            driver.FindElement(By.CssSelector(".all>a[href*=\"edit\"]")).Click();
        }

        protected void ReturnToEditPage()
        {
            driver.FindElement(By.CssSelector("div.msgbox a[href*=\"edit\"]")).Click();
        }

        protected void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"get\"]>input[name=\"new\"]")).Click();
        }

        protected void FillGroupForm(GroupData group)
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

        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[type=\"submit\"]")).Click();
        }

        protected void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"firstname\"]")).Click();
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"firstname\"]")).Clear();
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"firstname\"]")).SendKeys(contact.Firstname);
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"lastname\"]")).Click();
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"lastname\"]")).Clear();
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"lastname\"]")).SendKeys(contact.Lastname);
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"middlename\"]")).Click();
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"middlename\"]")).Clear();
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"middlename\"]")).SendKeys(contact.Middlename);
        }

        protected void SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"submit\"]")).Click();
        }

        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        protected void RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
        }


    }
}
