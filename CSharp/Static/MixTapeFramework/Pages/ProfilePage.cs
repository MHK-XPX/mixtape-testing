using OpenQA.Selenium;

namespace MixTapeFramework.Pages
{
    public static class ProfilePage
    {
        private static string Url = Driver.BaseUrl + "/#/profile";

        #region Elements
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

        public static IWebElement UserName
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputUserName"));
            }
        }

        public static IWebElement Password
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputPassword"));
            }
        }

        public static IWebElement PasswordConfirm
        {
            get
            {
                return Driver.Instance.FindElement(By.Id("inputCPassword"));
            }
        }

        public static IWebElement SaveChanges
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("form > div:nth - child(6) > div > button.btn.btn - primary"));
            }
        }

        public static IWebElement Cancel
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("form > div:nth-child(6) > div > button.btn.btn-outline-danger"));
            }
        }
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

        public static ProfileCommand UpdateInfo()
        {
            return new ProfileCommand();
        }

        public static void CancelUpdate()
        {
            Cancel.Click();
        }
    }

    public class ProfileCommand
    {
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string passwordConfirm;

        public ProfileCommand()
        {
            firstName = "";
            lastName = "";
            username = "";
            password = "";
            passwordConfirm = "";
        }

        public ProfileCommand WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public ProfileCommand WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public ProfileCommand WithUserName(string username)
        {
            this.username = username;
            return this;
        }

        public ProfileCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public ProfileCommand WithPasswordConfirm(string passwordConfirm)
        {
            this.passwordConfirm = passwordConfirm;
            return this;
        }

        public void Save()
        {
            if (firstName != "") ProfilePage.FirstName.SendKeys(firstName);
            if (lastName != "") ProfilePage.LastName.SendKeys(lastName);
            if (username != "") ProfilePage.UserName.SendKeys(username);
            if (password != "") ProfilePage.Password.SendKeys(password);
            if (passwordConfirm != "") ProfilePage.PasswordConfirm.SendKeys(passwordConfirm);
            ProfilePage.SaveChanges.Click();
        }
    }
}
