using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumTestAssignment.PageObject
{
    class ChromeAppPage
    {

        [FindsBy(How = How.Id, Using = "ios_menu")]
        public IWebElement expandBtn { get; set; }

        [FindsBy(How = How.Id, Using = "menulink menu-link-6")]
        public IWebElement contactsLink { get; set; }

    }

}
