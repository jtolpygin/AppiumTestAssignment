using System;
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
        WebDriverWait wait;

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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("http://gmail.com/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            GmailAppPage GmailAppPage = new GmailAppPage();
            PageFactory.InitElements(driver, GmailAppPage);

            //Gmail login
            IWebElement enterusernameLbl = wait.Until(ExpectedConditions.ElementToBeClickable(GmailAppPage.enterEmail));
            enterusernameLbl.SendKeys(GmailAppPage.username);
            IWebElement nextBtn = wait.Until(ExpectedConditions.ElementToBeClickable(GmailAppPage.btnNext));
            nextBtn.Click();
            IWebElement enterPasswordLbl = wait.Until(ExpectedConditions.ElementToBeClickable(GmailAppPage.enterPassword));
            enterPasswordLbl.Click();
            driver.Keyboard.SendKeys(GmailAppPage.password);
            IWebElement nextpasswordBtn = wait.Until(ExpectedConditions.ElementToBeClickable(GmailAppPage.btnPasswordNext));
            nextpasswordBtn.Click();
            Thread.Sleep(7000);

            if (driver.Url.Contains("https://mail.google.com/mail/mu/mp/263/#tl/priority/%5Esmartlabel_personal"))
            {
                Console.WriteLine("Login was successful.");
                driver.CloseApp();
            }

            else
            {
                Assert.Fail("Login was not sucessful.");
            }


        }
        public void RefreshCurrentPage()
        {
            driver.Navigate().Refresh();
        }
        public void LaunchAppAgain()
        {
            driver.LaunchApp();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("http://gmail.com/");
            Console.WriteLine("Launching App again.");

        }


    }
}

