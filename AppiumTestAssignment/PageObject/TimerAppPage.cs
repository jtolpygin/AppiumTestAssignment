using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumTestAssignment.PageObject
{
    class TimerAppPage
    {
        [FindsBy(How = How.XPath, Using = "//android.widget.ImageView[@content-desc='Timer']")]
        public IWebElement btnAlarm { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='1']")]
        public IWebElement btnOne { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='0']")]
        public IWebElement btnZero { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.ImageButton[@content-desc='Start']")]
        public IWebElement btnStartTimer { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.ImageButton[@content-desc='Stop']")]
        public IWebElement btnStopTimer { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.ImageButton[@content-desc='Delete']")]
        public IWebElement btnRemove { get; set; }

        [FindsBy(How = How.Id, Using = "com.android.deskclock:id/seconds")]
        public IWebElement timer { get; set; }

    }
}
