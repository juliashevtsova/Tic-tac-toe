using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        public void ChangeScoreFirstPlayer()
        {
           WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var mainPage = new MainPage(_webDriver);
            mainPage.OpenPage();
            mainPage.ChangePayersNumber();
            mainPage.InputSquare();
            mainPage.InputSquareBottom();
            mainPage.InputSquareBottomLeft();
            mainPage.InputSquareBottomRight();
            mainPage.InputSquareTopRight();
            var result = _webDriver.FindElement(By.CssSelector("p[class = player1]> span[class = 'score appear']")).Text;
            Assert.AreEqual("1",result);
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

        [Test]
        public void ChangePlayersNumber()
        {
            var mainPage = new MainPage(_webDriver);
            mainPage.OpenPage();
            mainPage.ChangePayersNumber();

            var result = _webDriver.FindElement(By.CssSelector(" p[class = p2]")).Text;

            Assert.AreEqual("2È", result);
        }

        [Test]
        public void GoNeaveInteractivePage()
        {

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            var mainPage = new MainPage(_webDriver);
            mainPage.OpenPage();
            mainPage.ClickNeaveInteractiveButton();

            wait.Until(ExpectedConditions.UrlMatches("https://playtictactoe.org/#google_vignette"));

            var result = _webDriver.Url;

            Assert.AreEqual("https://playtictactoe.org/#google_vignette", result);
        }       
    }
}