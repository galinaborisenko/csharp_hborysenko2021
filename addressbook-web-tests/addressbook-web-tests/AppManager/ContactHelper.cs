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
        public ContactHelper(ApplicationManager manager)
          : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.CssSelector(".all>a[href*=\"edit\"]")).Click();
            return this;
        }

        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.CssSelector("div.msgbox a[href*=\"edit\"]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).Click();
            driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).SendKeys(contact.Firstname);
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).Click();
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).SendKeys(contact.Lastname);
            driver.FindElement(By.CssSelector("input[name=\"middlename\"]")).Click();
            driver.FindElement(By.CssSelector("input[name=\"middlename\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"middlename\"]")).SendKeys(contact.Middlename);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"submit\"]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@onclick='DeleteSel()'])")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector(".center a[href*=\"edit\"]")).Click(); ;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"] input[name=\"update\"]")).Click();
            return this;
        }
    }
}
