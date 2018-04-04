using MixTapeCoypuFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MixTapeTests
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Setup()
        {
            Driver.Initialize(Driver.DriverTypes.Chrome);
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
