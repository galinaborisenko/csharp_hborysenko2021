﻿using System;
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
        public LoginLogoutHelper(ApplicationManager manager)
            : base (manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"),account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn()) 
            {
                driver.FindElement(By.CssSelector(".header a[onclick*=\"logout\"]")).Click();
                driver.FindElement(By.Name("user"));
            }        
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")";
        }

    }
}
