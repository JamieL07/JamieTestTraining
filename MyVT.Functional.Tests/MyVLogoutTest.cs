using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Facebook.FunctionalTests
{
    public class LogoutTest
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
        public void SignOutTest()
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
            input1.SendKeys("");

            //Enter Password
            Thread.Sleep(3000);
            var input2 = WebDriver.FindElement(By.Id("password"));
            input2.Clear();
            input2.SendKeys("");

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

            //Click on SignOut
            var input6 = WebDriver.FindElement(By.CssSelector("body > header > div > div.govuk-header__content > a.sign-out-link.govuk-header__link"));
            input6.Click();
            Thread.Sleep(5000);
            Assert.That(WebDriver.Title, Is.EqualTo("Manage your vehicle testing"));

        }

        private WebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            //options.AddArguments("--headless");

            return new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));

        }
    }
}