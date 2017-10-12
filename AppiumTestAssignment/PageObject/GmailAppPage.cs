using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumTestAssignment.PageObject
{
    class GmailAppPage
    {

        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement enterEmail { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement btnNext { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement enterPassword { get; set; }

        [FindsBy(How = How.Id, Using = "passwordNext")]
        public IWebElement btnPasswordNext { get; set; }
    }
}
