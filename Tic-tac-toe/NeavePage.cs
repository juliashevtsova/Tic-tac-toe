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
    public class NeavePage 
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