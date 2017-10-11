﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using AppiumTestAssignment.PageObject;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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

            //Assert.AreEqual("7", CalcAppPage.result.Text);
            if (CalcAppPage.result.Text == "7")
            {
                Console.WriteLine("sum of 3 + 4 equals " + CalcAppPage.result.Text);
                CalcAppPage.btnClear.Click();
                driver.CloseApp();
            }
            else
            {
                Assert.Fail("sum are not equal 7");
            }

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

            TimerAppPage TimerAppPage = new TimerAppPage();
            PageFactory.InitElements(driver, TimerAppPage);

            TimerAppPage.btnAlarm.Click();
            TimerAppPage.btnOne.Click();
            TimerAppPage.btnZero.Click();
            TimerAppPage.btnStartTimer.Click();
            Thread.Sleep(11000);
            TimerAppPage.btnStopTimer.Click();
            Thread.Sleep(2000);
            TimerAppPage.btnRemove.Click();

            //Assert.AreEqual("00", timer.Text);
            if (TimerAppPage.timer.Text == "00")
            {
                Console.WriteLine("Timer stopped and reset to base state.");
                driver.CloseApp();
            }
            else
            {
                Assert.Fail("Timer is not resets to base state.");
            }


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
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            ChromeAppPage ChromeAppPage = new ChromeAppPage();
            PageFactory.InitElements(driver, ChromeAppPage);
            ChromeAppPage.expandBtn.Click();
            ChromeAppPage.contactsLink.Click();


            Console.WriteLine("Contacts details found");
            driver.CloseApp();
        }

        [TestMethod]
        public void AppiumGmailLogin()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "PixelAppium");
            cap.SetCapability("PlatformName", "Android");
            cap.SetCapability("PlatformVersion", "7.1.1");
            cap.SetCapability("browserName", "Chrome");
            cap.SetCapability("appPackage", "com.android.chrome");
            cap.SetCapability("appActivity", "com.google.android.apps.chrome.Main");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            driver.Navigate().GoToUrl("http://gmail.com/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }
    }
}
