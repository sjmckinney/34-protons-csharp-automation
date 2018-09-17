using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace DotNetCore.Demo.Support
{
    public static class Driver
    {
        private static IWebDriver browser; //internal private instance of IWebDriver
        private static readonly string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static IWebDriver Browser  //public accessible instance of IWebDriver
        {
            get
            {
                if (browser == null)
                {
                    throw new NullReferenceException("Webdriver not initialised. Call StartBrowser method first.");
                }
                return browser;
            }
            private set => browser = value;
        }

        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Firefox, int defaultTimeOut = 30){
            switch(browserType){
                case BrowserTypes.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(executableLocation);
                    Driver.Browser = new FirefoxDriver(service);
                    break;
                case BrowserTypes.Chrome:
                    Driver.Browser = new ChromeDriver();
                    break;
                case BrowserTypes.MSEdge:
                    Driver.Browser = new EdgeDriver();
                    break;
                default:
                    throw new Exception($"Enum BrowserTypes does not contain type of {browserType}.");
            }
        }

        public static IWebDriver GetBrowser(){
            return Browser;
        }

        public static void StopBrowser(){
            Driver.Browser.Quit();
            browser = null;
        }
    }
}
