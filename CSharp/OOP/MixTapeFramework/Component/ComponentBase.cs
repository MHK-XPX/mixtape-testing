using OpenQA.Selenium;

namespace MixTapeFramework.Component
{
    public abstract class ComponentBase
    {
        protected IWebDriver driver;

        protected ComponentBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
