using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumTestAssignment.PageObject
{
    public class ChromeAppPage
    {

        [FindsBy(How = How.Id, Using = "ios_menu")]
        public IWebElement expandBtn { get; set; }

        [FindsBy(How = How.Id, Using = "menulink menu-link-6")]
        public IWebElement contactsLink { get; set; }

        [FindsBy(How = How.Id, Using = "menulink menu-link-5")]
        public IWebElement clientsLink { get; set; }

        [FindsBy(How = How.Id, Using = "menulink menu-link-4")]
        public IWebElement processLink { get; set; }

        [FindsBy(How = How.Id, Using = "menulink menu-link-3")]
        public IWebElement ourworkLink { get; set; }

        [FindsBy(How = How.Id, Using = "menulink menu-link-2")]
        public IWebElement servicesLink { get; set; }

        [FindsBy(How = How.Id, Using = "menulink menu-link-1")]
        public IWebElement homeLink { get; set; }

    }

}
