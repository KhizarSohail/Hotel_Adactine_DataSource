using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V108.Audits;

namespace Adactine_Hotel_Framework
{
    public class BaseClass
    {
        public static string path = "B:\\C-sharp Files\\Adactine_Hotel_Framework\\Adactine_Hotel_Framework\\Screenshot\\";
        public static IWebDriver driver;
        public static void SeleniumInit()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            driver = chromeDriver;
        }

        public static void Write(By by, string text, string detailname, string filename)
        {
            try
            {
                driver.FindElement(by).SendKeys(text);
                ExtentReport.Report_Log(detailname, filename);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void TakeScreenShot(string filename)
        {
            Screenshot sc = ((ITakesScreenshot)BaseClass.driver).GetScreenshot();
            sc.SaveAsFile(path + filename, ScreenshotImageFormat.Png);
        }
        public static void Nav()
        {
            driver.Navigate().GoToUrl("https://adactinhotelapp.com/");
        }
    }
}
