using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactine_Hotel_Framework
{
    internal class LoginPage : BaseClass
    {
        public void Login(string url, string user, string pass)
        {
            ExtentReport.Child_Log("Login Valid");
            driver.Url = url;
            driver.FindElement(By.Id("username")).SendKeys(user);
            ExtentReport.Report_Log("username", "username.png");
            driver.FindElement(By.Name("password")).SendKeys(pass);
            driver.FindElement(By.ClassName("login_button")).Click();
            BaseClass.driver.Close();

        }

    }
}
