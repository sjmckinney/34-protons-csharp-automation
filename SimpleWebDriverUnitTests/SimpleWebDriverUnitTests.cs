using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace DotNetCoreMsTests
{
    [TestClass]
    public class SimpleWebDriverUnitTests
    {
        [TestMethod]
        public void TestWithFirefoxDriver()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(executableLocation);

            using (var driver = new FirefoxDriver(service))
            {
                driver.Navigate().GoToUrl(@"https://www.34protons.co.uk/demo_2_0/");
                driver.FindElement(By.Id("clickMe")).Click();
                Assert.AreEqual("1", driver.FindElement(By.Id("nosClicks")).Text);

            }
        }
    }
}
