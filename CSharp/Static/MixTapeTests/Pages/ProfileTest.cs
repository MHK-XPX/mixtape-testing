using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Component;
using MixTapeCoypuFramework.Pages;

namespace MixTapeTests.Pages
{
    [TestClass]
    public class ProfileTest : TestBase
    {
        [TestMethod]
        public void ChangePassword()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("testuser").WithPassword("password").Login();
            ProfilePage.GoTo();
        }
    }
}
