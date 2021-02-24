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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
          : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"get\"]>input[name=\"new\"]")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
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
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"submit\"]")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.CssSelector("form[method=\"get\"]>input[name=\"edit\"]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[name=\"update\"]")).Click();
            return this;
        }


    }
}
