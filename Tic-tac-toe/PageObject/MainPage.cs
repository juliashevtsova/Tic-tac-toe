using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_tac_toe.PageObject
{
    class MainPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _squareTopLeft = By.CssSelector("[class='square top left']");
        private static readonly By _squareTop = By.CssSelector("[class = 'square top']");
        private static readonly By _squareTopRight = By.CssSelector("[class='square top right']");
        private static readonly By _squareLeft = By.CssSelector("[class='square left']");
        private static readonly By _square = By.CssSelector("[class=square]");
        private static readonly By _squareRight = By.CssSelector("[class='square right']");
        private static readonly By _squareBottomLeft = By.CssSelector("[class='square bottom left']");
        private static readonly By _squareBottom = By.CssSelector("[class='square bottom']");
        private static readonly By _squareBottomRight = By.CssSelector("[class='square bottom right']");
        private static readonly By _scoreButton = By.CssSelector("[class^=scores]");
        private static readonly By _playersNumber = By.CssSelector("[class^=swap]");

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://playtictactoe.org/");
            return this;
        }
        public MainPage ChangePayersNumber()
        {
            _webDriver.FindElement(_playersNumber).Click();
            return this;
        }
        public MainPage ChangeScoreNumber()
        {
            _webDriver.FindElement(_scoreButton);
            return this;
        }

        public void InputSquareTopLeft()
        {
            _webDriver.FindElement(_squareTopLeft).Click();
        }
        public void InputSquareTop()
        {
            _webDriver.FindElement(_squareTop).Click();
        }
        public void InputSquareTopRight()
        {
            _webDriver.FindElement(_squareTopRight).Click();
        }
        public void InputSquareLeft()
        {
            _webDriver.FindElement(_squareLeft).Click();
        }
        public void InputSquare()
        {
            _webDriver.FindElement(_square).Click();
        }
        public void InputSquareRight()
        {
            _webDriver.FindElement(_squareRight).Click();
        }
        public void InputSquareBottomLeft()
        {
            _webDriver.FindElement(_squareBottomLeft).Click();
        }
        public void InputSquareBottom()
        {
            _webDriver.FindElement(_squareBottom).Click();
        }
        public void InputSquareBottomRight()
        {
            _webDriver.FindElement(_squareBottomRight).Click();
        }       
       
    }
}

