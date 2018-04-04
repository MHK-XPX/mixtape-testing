﻿using Coypu;
using MixTapeCoypuFramework.Component;

namespace MixTapeCoypuFramework.Pages
{
    public static class ProfilePage
    {
        private static string Url = Driver.BaseUrl + "/#/profile";

        #region Elements
        public static ElementScope FirstName
        {
            get
            {
                return Driver.Instance.FindId("inputFirstName");
            }
        }

        public static ElementScope LastName
        {
            get
            {
                return Driver.Instance.FindId("inputLastName");
            }
        }

        public static ElementScope UserName
        {
            get
            {
                return Driver.Instance.FindId("inputUserName");
            }
        }

        public static ElementScope Password
        {
            get
            {
                return Driver.Instance.FindId("inputPassword");
            }
        }

        public static ElementScope PasswordConfirm
        {
            get
            {
                return Driver.Instance.FindId("inputCPassword");
            }
        }

        public static ElementScope SaveChanges
        {
            get
            {
                return Driver.Instance.FindButton("Save Changes");
            }
        }

        public static ElementScope Cancel
        {
            get
            {
                return Driver.Instance.FindButton("Cancel");
            }
        }
        #endregion

        public static void GoTo()
        {
            //Driver.GoTo(Url);
            Navbar.Profile();
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
