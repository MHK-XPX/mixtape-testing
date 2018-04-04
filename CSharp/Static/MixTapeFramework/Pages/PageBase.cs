using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTapeFramework.Pages
{
    public abstract class PageBase
    {
        protected const string base_url = "https://mhk-xpx.github.io/mixtape-frontend/";
        
        public static string Title
        {
            get
            {
                return Driver.Instance.Title;
            }
        }

        public abstract string Url
        {
            get;
        }

        public static bool IsAt
        {
            get
            {
                return string.Equals(Driver.Instance.Url, Url);
            }
        }
    }
}
