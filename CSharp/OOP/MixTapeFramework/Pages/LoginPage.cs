using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MixTapeFramework.Pages
{
    public class LoginPage : PageBase
    {
        public override string Url
        {
            get
            {
                return base_url + "/#/login";
            }
        }

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        #region Elements
        public IWebElement username
        {
            get
            {
                return driver.FindElement(By.Id("inputEmail3"));
            }
        }

        public IWebElement password
        {
            get
            {
                return driver.FindElement(By.Id("inputPassword3"));
            }
        }

        public IWebElement loginButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("form > button"));
            }
        }

        public IWebElement rememberMe
        {
            get
            {
                return driver.FindElement(By.CssSelector("input[type='checkbox'"));
            }
        }

        public IWebElement createAccount
        {
            get
            {
                return driver.FindElement(By.LinkText("Create an account*"));
            }
        }
        #endregion

        public LoginCommand Login(string username)
        {
            return new LoginCommand(username, this);
        }

        public void LoginWithDefault()
        {
            username.SendKeys("testuser");
            password.SendKeys("password");
            loginButton.Click();
        }
    }

    public class LoginCommand
    {
        private readonly string username;
        private readonly LoginPage loginPage;
        private string password;

        public LoginCommand(string username, LoginPage loginPage)
        {
            this.username = username;
            this.loginPage = loginPage;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            loginPage.username.SendKeys(username);
            loginPage.password.SendKeys(password);
            loginPage.loginButton.Click();
        }
    }
}
