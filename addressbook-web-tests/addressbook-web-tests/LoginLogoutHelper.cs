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
    public class LoginLogoutHelper : HelperBase
    {
        public LoginLogoutHelper(IWebDriver driver)
            : base (driver)
        {
        }
        public void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"user\"]")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Click();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).Clear();
            driver.FindElement(By.CssSelector("#LoginForm input[name=\"pass\"]")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("#LoginForm input[type=\"submit\"]")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.CssSelector(".header a[onclick*=\"logout\"]")).Click();
        }
    }
}
