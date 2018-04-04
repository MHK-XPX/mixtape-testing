using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeFramework.Pages;
using System.Threading;

namespace MixTapeTests
{
    [TestClass]
    public class LoginTest : TestBase
    {
        [TestMethod]
        public void Login()
        {
            LoginPage login = pages.LoginPage();
            browser.GoTo(login.Url);

            login.Login("testuser").WithPassword("password").Login();
            Thread.Sleep(5000);
        }
    }
}
