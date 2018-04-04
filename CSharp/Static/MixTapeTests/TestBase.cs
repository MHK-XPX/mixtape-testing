using MixTapeCoypuFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixTapeCoypuFramework.Pages;

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

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
