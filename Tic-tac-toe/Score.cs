using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PageObject;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Tic_tac_toe
{
    public class Score
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
        public void ChangeScoreFirstPlayer()
        {            
            var mainPage = new MainPage(_webDriver);

            mainPage.OpenPage();
            mainPage.ChangePayersNumber();
            mainPage.InputSquare();
            mainPage.InputSquareBottom();
            mainPage.InputSquareBottomLeft();
            mainPage.InputSquareBottomRight();
            mainPage.InputSquareTopRight();

            var result = _webDriver.FindElement(By.CssSelector("p[class = player1]> span[class = 'score appear']")).Text;
            
            Assert.AreEqual("1", result);
        }

        [Test]
        public void ChangeScoreSecondPlayer()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var mainPage = new MainPage(_webDriver);

            mainPage.OpenPage();
            mainPage.ChangePayersNumber();
            mainPage.InputSquareBottom();
            mainPage.InputSquare();
            mainPage.InputSquareBottomRight();
            mainPage.InputSquareBottomLeft();
            mainPage.InputSquareTopLeft();
            mainPage.InputSquareTopRight();

            var result = _webDriver.FindElement(By.CssSelector("p[class = player2]> span[class = 'score appear']")).Text;
            
            Assert.AreEqual("1", result);
        }

        [Test]
        public void ChangeDrawScore()
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var mainPage = new MainPage(_webDriver);

            mainPage.OpenPage();
            mainPage.ChangePayersNumber();
            mainPage.InputSquareBottomLeft();
            mainPage.InputSquareBottom();
            mainPage.InputSquareBottomRight();
            mainPage.InputSquareTopLeft();
            mainPage.InputSquareLeft();
            mainPage.InputSquareRight();
            mainPage.InputSquareTop();
            mainPage.InputSquareTopRight();
            mainPage.InputSquareTopLeft();
            mainPage.InputSquare();

            var result = _webDriver.FindElement(By.CssSelector("p[class = ties]> span[class = 'score appear']")).Text;
            
            Assert.AreEqual("1", result);
        }
    }
}