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
    public class ContactCreationTests
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
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            OpenEditPage();
            ContactData contact = new ContactData("first", "last");
            contact.Middlename = "middle";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToEditPage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.CssSelector(".header a[onclick*=\"logout\"]")).Click();
        }

        private void ReturnToEditPage()
        {
            driver.FindElement(By.CssSelector("div.msgbox a[href*=\"edit\"]")).Click();
        }

        private void SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"submit\"]")).Click();
        }

        private void FillContactForm(ContactData contact)
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

        private void OpenEditPage()
        {
            driver.FindElement(By.CssSelector(".all>a[href*=\"edit\"]")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("#LoginForm input[type=\"submit\"")).Click();
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
