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
        public GroupHelper(IWebDriver driver)
          : base(driver)
        {
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"get\"]>input[name=\"new\"]")).Click();
        }

        public void FillGroupForm(GroupData group)
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

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("form[method=\"post\"]>input[type=\"submit\"]")).Click();
        }
        public void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
        }

    }
}
