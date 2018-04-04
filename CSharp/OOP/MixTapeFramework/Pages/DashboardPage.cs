using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MixTapeFramework.Pages
{
    public class DashboardPage : PageBase
    {
        public override string Url
        {
            get
            {
                return base_url + "/#/home";
            }
        }

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
