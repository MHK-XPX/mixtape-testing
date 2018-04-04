using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Component;
using MixTapeCoypuFramework.Pages;

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
            Assert.AreEqual(Navbar.User, "testuser");
        }

        [TestMethod]
        public void Logout()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("testuser").WithPassword("password").Login();
            Assert.AreEqual(Navbar.User, "testuser");
            Navbar.Logout();
            Assert.IsTrue(LoginPage.IsAt);
        }
    }
}
