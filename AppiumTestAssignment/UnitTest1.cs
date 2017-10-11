using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using AppiumTestAssignment.PageObject;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumTestAssignment
{
    [TestClass]
    public class UnitTest1
    {
        AppiumDriver<IWebElement> driver;

        [TestMethod]
        public void AppiumTestCalculator()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "PixelAppium");
            cap.SetCapability("PlatformName", "Android");
            cap.SetCapability("PlatformVersion", "7.1.1");
            cap.SetCapability("appPackage", "com.android.calculator2");
            cap.SetCapability("appActivity", "com.android.calculator2.Calculator");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            CalcAppPage CalcAppPage = new CalcAppPage();
            PageFactory.InitElements(driver, CalcAppPage);
            CalcAppPage.btnThree.Click();
            CalcAppPage.btnPlus.Click();
            CalcAppPage.btnFour.Click();
            CalcAppPage.btnEqualsTo.Click();

            Assert.AreEqual("7", CalcAppPage.result.Text);
            
            Console.WriteLine("sum of 3 + 4 equals 7.");
            CalcAppPage.btnClear.Click();
            driver.CloseApp();
        }
        [TestMethod]
        public void AppiumTestTimer()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "PixelAppium");
            cap.SetCapability("PlatformName", "Android");
            cap.SetCapability("PlatformVersion", "7.1.1");
            cap.SetCapability("appPackage", "com.android.deskclock");
            cap.SetCapability("appActivity", "com.android.deskclock.DeskClock");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            var btnAlarm = driver.FindElementByXPath("//android.widget.ImageView[@content-desc='Timer']");
            btnAlarm.Click();
            var btnOne = driver.FindElementByXPath("//android.widget.Button[@text='1']");
            btnOne.Click();
            var btnZero = driver.FindElementByXPath("//android.widget.Button[@text='0']");
            btnZero.Click();
            var btnStartTimer = driver.FindElementByXPath("//android.widget.ImageButton[@content-desc='Start']");
            btnStartTimer.Click();
            System.Threading.Thread.Sleep(11000);
            var btnStopTimer = driver.FindElementByXPath("//android.widget.ImageButton[@content-desc='Stop']");
            btnStopTimer.Click();
            System.Threading.Thread.Sleep(2000);
            var btnRemove = driver.FindElementByXPath("//android.widget.ImageButton[@content-desc='Delete']");
            btnRemove.Click();

            var timer = driver.FindElementById("com.android.deskclock:id/seconds");

            Assert.AreEqual("00", timer.Text);
            Console.WriteLine("Timer stopped and reset to base state.");        
            driver.CloseApp();
        }
        [TestMethod]
        public void AppiumTestChrome()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "PixelAppium");
            cap.SetCapability("PlatformName", "Android");
            cap.SetCapability("PlatformVersion", "7.1.1");
            cap.SetCapability("browserName", "Chrome");
            cap.SetCapability("appPackage", "com.android.chrome");
            cap.SetCapability("appActivity", "com.google.android.apps.chrome.Main");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            driver.Navigate().GoToUrl("http://www.fob-solutions.com/");
            System.Threading.Thread.Sleep(2000);

            ChromeAppPage ChromeAppPage = new ChromeAppPage();
            PageFactory.InitElements(driver, ChromeAppPage);
            ChromeAppPage.expandBtn.Click();
            ChromeAppPage.contactsLink.Click();

            Console.WriteLine("Contacts details found.");
            driver.CloseApp();
        }
    }
}
