using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MixTapeFramework.Pages
{
    public static class DashboardPage
    {
        private static string Url = Driver.BaseUrl + "/#/home";

        public static void GoTo()
        {
            Driver.GoTo(Url);
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
