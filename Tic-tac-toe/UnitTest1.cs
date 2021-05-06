using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Tic_tac_toe.PageObject;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Tic_tac_toe
{
    public class Tests
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
        public void Test1()
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.OpenPage();
            mainPage.ChangePayersNumber();
            mainPage.InputSquare();
            mainPage.InputSquareBottom();
            mainPage.InputSquareBottomLeft();
            mainPage.InputSquareBottomRight();
            mainPage.InputSquareTopRight();

           // var result = _webDriver.FindElement(By.CssSelector("body > div.scores.p2 > p.player1 > span.score.appear"));

            Assert.AreEqual(1, result);
        }
    }
}