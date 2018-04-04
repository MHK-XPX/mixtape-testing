using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Component;
using MixTapeCoypuFramework.Pages;
using System.Threading;

namespace MixTapeTests
{
    [TestClass]
    public class LoginTest : TestBase
    {
        [TestMethod]
        public void Login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("testuser").WithPassword("password").Login();
            //Thread.Sleep(10000);
            ProfilePage.GoTo();
            Thread.Sleep(3000);
            NavbarComponent.GoHome();
            Thread.Sleep(3000);
            NavbarComponent.Logout();
            Thread.Sleep(3000);
        }
    }
}
