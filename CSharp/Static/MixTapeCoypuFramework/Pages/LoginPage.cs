using Coypu;
using MixTapeCoypuFramework.Component;

namespace MixTapeCoypuFramework.Pages
{
    /// <summary>
    /// The Login page object, handles the Login page functionality
    /// </summary>
    public class LoginPage
    {
        public static string Url = "/#/login";

        #region Elements
        #region Login Page
        public static ElementScope UserName
        {
            get
            {
                return Driver.Instance.FindId("inputEmail3");
            }
        }

        public static ElementScope Password
        {
            get
            {
                return Driver.Instance.FindId("inputPassword3");
            }
        }

        public static ElementScope LoginButton
        {
            get
            {
                return Driver.Instance.FindButton("Sign In");
            }
        }

        public static ElementScope RememberMe
        {
            get
            {
                return Driver.Instance.FindCss("input[type='checkbox'");
            }
        }

        public static ElementScope CreateAccountLink
        {
            get
            {
                return Driver.Instance.FindLink("Create an account");
            }
        }
        #endregion
        #region Create Page
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
        public static ElementScope NewUserName
        {
            get
            {
                return Driver.Instance.FindId("inputUsername");
            }
        }

        public static ElementScope NewPassword
        {
            get
            {
                return Driver.Instance.FindId("inputPassword");
            }
        }

        public static ElementScope NewPasswordConfirm
        {
            get
            {
                return Driver.Instance.FindId("inputCPassword");
            }
        }

        public static ElementScope CreateAccountButton
        {
            get
            {
                return Driver.Instance.FindButton("Create Account");
            }
        }

        public static ElementScope Cancel
        {
            get
            {
                return Driver.Instance.FindLink("Cancel");
            }
        }
        #endregion
        #endregion

        public static void GoTo()
        {
            Driver.GoTo(PageTypes.Login);
        }

        public static bool IsAt
        {
            get
            {
                return Driver.IsAt(Url);
            }
        }

        /// <summary>
        /// Checks to see if the "Invalid username/password" message is displayed
        /// </summary>
        public static bool IsInvalid
        {
            get
            {
                try
                {
                    // If the Id is not null, then the alert exists and we have an invalid username or password
                    return Driver.Instance.FindCss("login > ngb-alert > div").Id != null;
                }
                catch (Coypu.MissingHtmlException e)
                {
                    return false;
                }
            }
        }

        public static LoginCommand LoginAs(string username)
        {
            Driver.CheckLocation(PageTypes.Login);
            return new LoginCommand(username);
        }

        public static void LoginWithDefault()
        {
            Driver.CheckLocation(PageTypes.Login);
            UserName.FillInWith("testuser");
            Password.FillInWith("password");
            LoginButton.Click();
        }

        public static CreateCommand CreateNewAccount()
        {
            Driver.CheckLocation(PageTypes.Login);
            CreateAccountLink.Click();
            return new CreateCommand();
        }
    }

    /// <summary>
    /// A command class to allow chaining for the "CreateNewAccount" method
    /// </summary>
    public class CreateCommand
    {
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string passwordConfirm;

        public CreateCommand()
        {
            firstName = "";
            lastName = "";
            username = "";
            password = "";
            passwordConfirm = "";
        }

        public CreateCommand WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public CreateCommand WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public CreateCommand WithUserName(string username)
        {
            this.username = username;
            return this;
        }

        public CreateCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public CreateCommand WithPasswordConfirm(string passwordConfirm)
        {
            this.passwordConfirm = passwordConfirm;
            return this;
        }

        public void Create()
        {
            if (firstName != "") LoginPage.FirstName.FillInWith(firstName);
            if (lastName != "") LoginPage.LastName.FillInWith(lastName);
            if (username != "") LoginPage.NewUserName.FillInWith(username);
            if (password != "") LoginPage.NewPassword.FillInWith(password);
            if (passwordConfirm != "") LoginPage.NewPasswordConfirm.FillInWith(passwordConfirm);
            LoginPage.CreateAccountButton.Click();
        }
    }

    /// <summary>
    /// A command class to allow chaining for the "LoginAs" method
    /// </summary>
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
            LoginPage.UserName.FillInWith(username);
            LoginPage.Password.FillInWith(password);
            if (rememberMe) LoginPage.RememberMe.Check();
            LoginPage.LoginButton.Click();
        }
    }
}
