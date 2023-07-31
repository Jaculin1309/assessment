using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.Source
{
    public class LoginModule
    {
        public IWebDriver Driver { get; private set; }

        // Constructor
        public LoginModule(IWebDriver driver)
        {
            Driver = driver;
        }

        // Methods to interact with the login page
        public void EnterUsername(string username)
        {
            Driver.FindElement(By.Id("user-name")).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(By.Id("password")).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(By.Id("login-button")).Click();
        }

        // Add any other helper methods or assertions related to the login page here
    }
}
