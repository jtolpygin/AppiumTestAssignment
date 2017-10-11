using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumTestAssignment.PageObject
{
    class CalcAppPage
    {
        [FindsBy(How = How.Id, Using = "com.android.calculator2:id/digit_3")]
        public IWebElement btnThree { get; set; }

        [FindsBy(How = How.Id, Using = "com.android.calculator2:id/op_add")]
        public IWebElement btnPlus { get; set; }

        [FindsBy(How = How.Id, Using = "com.android.calculator2:id/digit_4")]
        public IWebElement btnFour { get; set; }

        [FindsBy(How = How.Id, Using = "com.android.calculator2:id/eq")]
        public IWebElement btnEqualsTo { get; set; }

        [FindsBy(How = How.Id, Using = "com.android.calculator2:id/result")]
        public IWebElement result { get; set; }

        [FindsBy(How = How.Id, Using = "com.android.calculator2:id/clr")]
        public IWebElement btnClear { get; set; }

    }
}
