using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MixTapeCoypuFramework.Pages
{
    public class DashboardPage
    {
        public static string Url = "/#/home";

        public static void GoTo()
        {
            Driver.GoTo(PageTypes.Dashboard);
        }

        public static bool IsAt
        {
            get
            {
                return Driver.IsAt(Url);
            }
        }
    }
}
