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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]. //find row, cells and save value from each
               FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {

                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones,
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactDetails(index);
            string firstLastName = driver.FindElement(By.Id("content")).FindElement(By.TagName("b")).Text;           
            string contactInfo = driver.FindElement(By.Id("content")).FindElement(By.TagName("br")).Text;

            return new ContactData(firstLastName)
            {
                FirstLastName = firstLastName,
                ContactInfo = contactInfo,
            };
        }

        private ContactHelper OpenContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index] //find row
               .FindElements(By.TagName("td"))[6]//find cell #6
               .FindElement(By.TagName("a")).Click(); ;
            return this;
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
            WaitUntilElementNotVisible(By.CssSelector("div.msgbox"), 5);
            contactsCache = null;
            return this;
        }
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector(".center a[href*=\"edit\"]")).Click(); ;
            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index] //find row
                .FindElements(By.TagName("td"))[7]//find cell #7
                .FindElement(By.TagName("a")).Click(); ; 
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
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string lastName = cells[1].Text;
                    string firstName = cells[2].Text;
                    contactsCache.Add(new ContactData(firstName, lastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")  //присвоить свойство контакту Id
                    });
                }
            }
            return new List<ContactData>(contactsCache);
        }
      }
    }
   
