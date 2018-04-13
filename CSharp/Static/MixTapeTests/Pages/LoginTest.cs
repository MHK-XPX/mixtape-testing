using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Component;
using MixTapeCoypuFramework.Pages;

namespace MixTapeTests.Pages
{
    [TestClass]
    public class LoginTest : TestBase
    {
        /// <summary>
        /// Tests a valid login
        /// </summary>
        [TestMethod]        
        public void Login()
        {
            LoginPage.LoginAs(Username).WithPassword(Password).Login();
            Assert.AreEqual(Navbar.User, Username);
        }

        /// <summary>
        /// Tests a login with an invalid username
        /// </summary>
        [TestMethod]
        public void LoginWithInvalidUsername()
        {
            LoginPage.LoginAs(Username + "bad").WithPassword(Password).Login();
            Assert.IsTrue(LoginPage.IsInvalid);
        }

        /// <summary>
        /// Tests a login with an invalid password
        /// </summary>
        [TestMethod]
        public void LoginWithInvalidPassword()
        {
            LoginPage.LoginAs(Username).WithPassword(Password + "bad").Login();
            Assert.IsTrue(LoginPage.IsInvalid);
        }

        /// <summary>
        /// Tests the logout functionality
        /// </summary>
        [TestMethod]
        public void Logout()
        {
            LoginPage.LoginAs(Username).WithPassword(Password).Login();
            Assert.AreEqual(Navbar.User, Username);
            Navbar.Logout();
            Assert.IsTrue(LoginPage.IsAt);
        }
    }
}
