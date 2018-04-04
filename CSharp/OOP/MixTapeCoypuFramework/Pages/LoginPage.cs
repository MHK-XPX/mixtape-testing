using Coypu;

namespace MixTapeCoypuFramework.Pages
{
    public class LoginPage : PageBase
    {
        private const string PAGE_URL = "/#/login";

        public override string Url
        {
            get
            {
                return base_url + PAGE_URL;
            }
        }

        public LoginPage(BrowserSession browserSession) : base(browserSession)
        {
        }

        #region Elements
        public ElementScope username
        {
            get
            {
                return browserSession.FindId("inputEmail3");
            }
        }

        public ElementScope password
        {
            get
            {
                return browserSession.FindId("inputPassword3");
            }
        }

        public ElementScope loginButton
        {
            get
            {
                return browserSession.FindButton("");
            }
        }

        public ElementScope rememberMe
        {
            get
            {
                return browserSession.FindCss("input[type='checkbox'");
            }
        }

        public ElementScope createAccount
        {
            get
            {
                return browserSession.FindLink("Create an account*");
            }
        }
        #endregion

        public LoginCommand Login(string username)
        {
            return new LoginCommand(username, this);
        }

        public void LoginWithDefault()
        {
            username.FillInWith("testuser");
            password.FillInWith("password");
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
            loginPage.username.FillInWith(username);
            loginPage.password.FillInWith(password);
            loginPage.loginButton.Click();
        }
    }
}
