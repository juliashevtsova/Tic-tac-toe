using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Tic_tac_toe
{
    public class Players
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20000);
        }

        [Test]
        public void ChangeNumberOfPlayersByTwo()
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.OpenPage();
            mainPage.ChangePayersNumber();

            var result = _webDriver.FindElement(By.CssSelector(" p[class = p2]")).Text;

            Assert.AreEqual("2И", result);
        }

        [Test]
        public void ChangePlayerToComputer()
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.OpenPage();
            mainPage.ChangePayersNumber();
            mainPage.ChangePayersNumber();

            var result = _webDriver.FindElement(By.CssSelector(" p[class = p1]")).Text;
            var namePlayer2 = _webDriver.FindElement(By.CssSelector("p.player2>span.p1")).Text;

            Assert.Multiple(() => {
                Assert.AreEqual("1И", result);
                Assert.AreEqual("КОМПЬЮТЕР", namePlayer2);
            });
        }

    }
}