using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using static DotNetCore.Demo.Support.Driver;

namespace DotNetCore.Demo.MsTests
{
    [TestClass]
    public class SimpleWebDriverUnitTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            StartBrowser();
        }

        [TestMethod]
        public void TestWithFirefoxDriver()
        {
            {
                Browser.Navigate().GoToUrl(@"https://www.34protons.co.uk/demo_2_0/");
                Browser.FindElement(By.Id("clickMe")).Click();

                Assert.AreEqual("1", Browser.FindElement(By.Id("nosClicks")).Text);
            }
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            StopBrowser();
        }
    }
}
