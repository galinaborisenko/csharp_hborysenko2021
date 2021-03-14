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
            driver.FindElement(By.CssSelector("div.msgbox a[href*=\"index\"]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.CssSelector("input[name=\"firstname\"]"), contact.Firstname);
            Type(By.CssSelector("input[name=\"lastname\"]"), contact.Lastname);
            Type(By.CssSelector("input[name=\"middlename\"]"), contact.Middlename);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("form[name=\"theform\"]>input[name=\"submit\"]")).Click();
            contactsCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@onclick='DeleteSel()'])")).Click();
            driver.SwitchTo().Alert().Accept();
            WaitUntilElementNotVisible(By.CssSelector(".msgbox [text*=\"deleted\"]"), 5);
            contactsCache = null;
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
            contactsCache = null;
            return this;
        }

        public bool IsContactElementExists()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.Name("selected[]"));
        }

        public void CreateContactIfDoesntExists(ContactData contact)
        {
            if (!IsContactElementExists())
            {
                Create(contact);
            }
        }

        private List<ContactData> contactsCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactsCache == null)
            {
                contactsCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    String s = element.Text;
                    contactsCache.Add((new ContactData(s.Substring(s.LastIndexOf(" ") + 1), s.Substring(0, s.IndexOf(" "))) //first argument  - the last word of string; second argument - the first name of string  
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    }));
                  }
                }
                return new List<ContactData>(contactsCache);
            }

        }
    }
   
