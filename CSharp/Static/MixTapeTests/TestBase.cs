using MixTapeCoypuFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MixTapeTests
{
    [TestClass]
    public class TestBase
    {
        public static string Username = Properties.Settings.Default.Username;
        public static string Password = Properties.Settings.Default.Password;

        [TestInitialize]
        public void Setup()
        {
            Driver.Initialize(DriverTypes.Chrome);
        }

        public void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
