using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver)
          : base(driver)
        {
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.CssSelector(".all>a[href*=\"edit\"]")).Click();
        }

        public void ReturnToEditPage()
        {
            driver.FindElement(By.CssSelector("div.msgbox a[href*=\"edit\"]")).Click();
        }

        public void FillContactForm(ContactData contact)
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

        public void SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"submit\"]")).Click();
        }
    }
}
