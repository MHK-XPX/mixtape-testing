using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MixTapeFramework.Pages
{
    public static class LoginPage
    {
        private static string Url = Driver.BaseUrl + "/#/login";

        #region Elements
        #region Login Page
        public static IWebElement UserName
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputEmail3"));
            }
        }

        public static IWebElement Password
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputPassword3"));
            }
        }

        public static IWebElement LoginButton
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("form > button"));
            }
        }

        public static IWebElement RememberMe
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("input[type='checkbox'"));
            }
        }

        public static IWebElement CreateAccountLink
        {
            get
            {
                return Driver.Instance.FindElement(By.LinkText("Create an account*"));
            }
        }
        #endregion
        #region Create Page
        public static IWebElement FirstName
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputFirstName"));
            }
        }
        public static IWebElement LastName
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputLastName"));
            }
        }
        public static IWebElement NewUserName
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputUsername"));
            }
        }

        public static IWebElement NewPassword
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputPassword"));
            }
        }

        public static IWebElement NewPasswordConfirm
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputCPassword"));
            }
        }

        public static IWebElement CreateAccountButton
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("form > button"));
            }
        }

        public static IWebElement Cancel
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("form > button"));
            }
        }
        #endregion
        #endregion

        public static void GoTo()
        {
            Driver.GoTo(Url);
        }

        public static bool IsAt
        {
            get
            {
                return Driver.IsAt(Url);
            }
        }

        public static LoginCommand LoginAs(string username)
        {
            return new LoginCommand(username);
        }

        public static void LoginWithDefault()
        {
            UserName.SendKeys("testuser");
            Password.SendKeys("password");
            LoginButton.Click();
        }

        public static void CreateNewAccount()
        {
            CreateAccountLink.Click();
        }
    }

    public class LoginCommand
    {
        private readonly string username;
        private string password;
        private bool rememberMe;

        public LoginCommand(string username)
        {
            this.username = username;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public LoginCommand WithRememberMe(bool rememberMe)
        {
            this.rememberMe = rememberMe;
            return this;
        }

        public void Login()
        {
            LoginPage.UserName.SendKeys(username);
            LoginPage.Password.SendKeys(password);
            if (rememberMe) LoginPage.RememberMe.Click();
            LoginPage.LoginButton.Click();
        }
    }
}
