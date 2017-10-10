using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;

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

            var btnThree = driver.FindElementById("com.android.calculator2:id/digit_3");
            btnThree.Click();
            var btnPlus = driver.FindElementById("com.android.calculator2:id/op_add");
            btnPlus.Click();
            var btnFour = driver.FindElementById("com.android.calculator2:id/digit_4");
            btnFour.Click();
            var btnEqualsTo = driver.FindElementById("com.android.calculator2:id/eq");
            btnEqualsTo.Click();

            var result = driver.FindElementById("com.android.calculator2:id/result");

            Assert.AreEqual("7", result.Text);
            Console.WriteLine("sum of 3 + 4 equals 7.");

            var btnClear = driver.FindElementById("com.android.calculator2:id/clr");
            btnClear.Click();
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
            System.Threading.Thread.Sleep(5000);
            var expandBtn = driver.FindElement(By.Id("ios_menu"));
            expandBtn.Click();
            System.Threading.Thread.Sleep(1000);
            var contactsLink = driver.FindElement(By.Id("menulink menu-link-6"));
            contactsLink.Click();
            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Contacts details found.");
            driver.CloseApp();
        }
    }
}
