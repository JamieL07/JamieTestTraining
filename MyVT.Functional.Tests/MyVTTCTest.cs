using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Facebook.FunctionalTests
{
    public class TCTest
    {
        private WebDriver WebDriver { get; set; } = null!;
        private string DriverPath { get; set; } = @"C:\WebDrivers\Chrome";
        private string BaseUrl { get; set; } = "https://myvttest.powerappsportals.com/";


        [SetUp]
        public void Setup()
        {
            WebDriver = GetChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }

        [TearDown]

        public void TearDown()
        {
            WebDriver.Quit();
        }

        [Test]
        public void TestLogin()
        {
            //Open Up MyVT
            WebDriver.Navigate().GoToUrl(BaseUrl);
            Assert.That(WebDriver.Title, Is.EqualTo("Manage your vehicle testing"));

            //Click on Sign In
            Thread.Sleep(2000);
            var input = WebDriver.FindElement(By.XPath("/html/body/main/div[2]/div/div/div/div/div/div/div/a"));
            input.Click();
            Thread.Sleep(2000);
            Assert.That(WebDriver.Title, Is.EqualTo("Sign in - Manage your vehicle testing"));

            //Enter Email
            var input1 = WebDriver.FindElement(By.Id("signInName"));
            input1.Clear();
            input1.SendKeys("Jamie@Cloudthing.com");

            //Enter Password
            Thread.Sleep(3000);
            var input2 = WebDriver.FindElement(By.Id("password"));
            input2.Clear();
            input2.SendKeys("Password123456!");

            //Click on Sign In Button
            Thread.Sleep(2000);
            var input3 = WebDriver.FindElement(By.Id("next"));
            input3.Click();

            //Accept Cookies 
            Thread.Sleep(5000);
            var input4 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[2]/button[1]"));
            input4.Click();

            //Click on Hide this message
            Thread.Sleep(2000);
            var input5 = WebDriver.FindElement(By.CssSelector("body > div.govuk-cookie-banner > div:nth-child(2) > div.govuk-button-group > button"));
            input5.Click();
            Thread.Sleep(3000);

            //Login Is Successful 
            Assert.That(WebDriver.Title, Is.EqualTo("Manage your vehicle testing"));

            //Click on T&Cs Page and ensure it's displayed correctly 
            Thread.Sleep(2000);
            var input6 = WebDriver.FindElement(By.CssSelector("body > footer > div > div > div.govuk-footer__meta-item.govuk-footer__meta-item--grow > ul > li:nth-child(3) > a"));
            input6.Click();
            Thread.Sleep(2000);
            Assert.That(WebDriver.Title, Is.EqualTo("Terms and conditions"));

        }

        private WebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            //options.AddArguments("--headless");

            return new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));

        }
    }
}