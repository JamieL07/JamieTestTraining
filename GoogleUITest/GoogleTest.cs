using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace UITestingTraining
{
    [TestClass]
    public class GoogleTest
    {
        [TestMethod]
        public void TestSearchStreetFighterVThenVerifyStreetFighterVIsDisplayed()
        {
            int waitingTime = 1000;
            By googleSearchBar = By.Name("q");
            By googleSearchButton = By.Name("btnK");
            By googleResultsText = By.XPath(".//h2/span[text()='Street Fighter V']");
            By googleIAgreeButton = By.Id("L2AGLb");


            IWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl("https://www.google.co.uk");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleIAgreeButton).Click();

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchBar).SendKeys("Street Fighter V");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchButton).Click();

            Thread.Sleep(waitingTime);

            var actualResultsText = webDriver.FindElement(googleResultsText);

            Assert.IsTrue(actualResultsText.Text.Equals("Street Fighter V"));

            webDriver.Quit();

        }
    }
}
