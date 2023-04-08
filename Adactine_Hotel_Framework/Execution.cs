using DemoQA_Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Adactine_Hotel_Framework
{
    [TestClass]
    public class Execution
    {
        LoginPage obj_login = new LoginPage();
        SearchHotel obj_sh = new SearchHotel();
        Register reg = new Register();

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [TestInitialize]
        public void TestInit()
        {
            ExtentReport.Report();
            BaseClass.SeleniumInit();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            ExtentReport.flush();
            BaseClass.driver.Close();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"Adactininfo.xml", "Login", DataAccessMethod.Sequential)]

        public void LoginWithValidUsernameAndPass()
        {
            
            string Url = TestContext.DataRow["url"].ToString();
            string Username = TestContext.DataRow["username"].ToString();
            string Password = TestContext.DataRow["password"].ToString();

            obj_login.Login(Url, Username, Password);
            //string Message = BaseClass.driver.FindElement(By.ClassName("welsome_menu")).Text;
            //Assert.AreEqual("Welcome to Adactin Group of Hotels", Message);

        }

        public static void TestContext_Method()
        {

        } 
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"Adactininfo.xml", "SearchHotel", DataAccessMethod.Sequential)]
        public void SearchHotel()
        {
            BaseClass.SeleniumInit();

            string Url = TestContext.DataRow["url"].ToString();
            string Username = TestContext.DataRow["username"].ToString();
            string Password = TestContext.DataRow["password"].ToString();
            string loc = TestContext.DataRow["location"].ToString();
            string hotels = TestContext.DataRow["hotels"].ToString();
            string rt = TestContext.DataRow["room_type"].ToString();
            string rno = TestContext.DataRow["room_nos"].ToString();
            string date_pick = TestContext.DataRow["datepick_in"].ToString();
            string date_pick_out = TestContext.DataRow["datepick_out"].ToString();
            string ar = TestContext.DataRow["adult_room"].ToString();
            string cr = TestContext.DataRow["child_room"].ToString();
            obj_sh.searchHotel(Url, Username, Password, loc, hotels, rt, rno, date_pick, date_pick_out, ar, cr);
        }

        [TestMethod]
        public void RegiTest()
        {
            BaseClass.SeleniumInit();
            reg.UserRegister();
            BaseClass.Nav();
            LoginWithValidUsernameAndPass();
        }

        [TestMethod]
        public void Demo_QA_Execution()
        {
            IWebDriver driver3 = new ChromeDriver();
            ExtentReport.Parent_Log(TestContext.TestName);
            ExtentReport.Child_Log("Demo Valid");


            driver3.Url = "https://demoqa.com/automation-practice-form";

            driver3.FindElement(By.XPath("//*[@id='firstName' or @name='First Name']")).SendKeys("Khizar");
            driver3.FindElement(By.XPath("//*[@id='lastName' or @name='Last Name']")).SendKeys("Sohail");
            driver3.FindElement(By.Id("userEmail")).SendKeys("abcxyz@gmail.com");
            driver3.FindElement(By.CssSelector("label[for = gender-radio-1]")).Click();

            driver3.FindElement(By.Id("userNumber")).SendKeys("1234556606");
            driver3.FindElement(By.Id("userNumber")).SendKeys(Keys.Tab);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver3;
            js.ExecuteScript("window.scrollBy(0, 600)");    

            driver3.FindElement(By.Id("dateOfBirthInput")).SendKeys("24 Aug 1999");
            //dob.SendKeys(Keys.Control + "a");

            driver3.FindElement(By.Id("subjectsInput")).SendKeys("English");
            driver3.FindElement(By.Id("subjectsInput")).SendKeys(Keys.Tab);

            driver3.FindElement(By.Id("userNumber")).Click();
            driver3.FindElement(By.CssSelector("label[for = hobbies-checkbox-1]")).Click();

            driver3.FindElement(By.XPath("//*[@id = 'uploadPicture']")).SendKeys("C:\\Users\\Com Plus\\Desktop\\file.txt");

            driver3.FindElement(By.Id("currentAddress")).SendKeys("My Address");

            //js.ExecuteScript("window.scrollTo(0, document." + "Bottom" + ".scrollHeight);");

            driver3.FindElement(By.Id("react-select-3-input")).SendKeys("Haryana");
            driver3.FindElement(By.Id("react-select-3-input")).SendKeys(Keys.Enter);


            driver3.FindElement(By.Id("react-select-4-input")).SendKeys("Karnal");
            driver3.FindElement(By.Id("react-select-4-input")).SendKeys(Keys.Enter);
            
            driver3.FindElement(By.Id("submit")).SendKeys(Keys.Enter);
            Screenshot screenshot = ((ITakesScreenshot)driver3).GetScreenshot();
            screenshot.SaveAsFile(@".\\demoqa_form.png", ScreenshotImageFormat.Png);
            //Thread.Sleep(5000);

            driver3.Close();
        }
        [TestMethod] 
        public void BrowserGotoUrlCommand() 
        { 
            IWebDriver driver = new ChromeDriver(); 
            driver.Url = "https://demoqa.com/"; 
            driver.Navigate().GoToUrl("https://adactinhotelapp.com/");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@".\\newcapture.png", ScreenshotImageFormat.Png);
            driver.Close(); 
        }
        [TestMethod] 
        public void GetElementCommand() 
        { 
            IWebDriver driver = new ChromeDriver(); 
            driver.Url = "https://demoqa.com/"; 
            var element = driver.FindElement(By.Id("id")); 
            element.GetAttribute("value"); 
            element.GetAttribute("text"); 
            element.GetAttribute("innerHTML"); 
        }
        [TestMethod] 
        public void GetElementState() 
        { 
            IWebDriver driver = new ChromeDriver(); 
            var element = driver.FindElement(By.Id("id")); 
            string elementState = element.GetAttribute("Disabled"); 
            if (elementState == null) 
            { 
                elementState = "enabled"; 

            } 
            else if (elementState == "true") 

            { 
                elementState = "disabled"; 
            } 
        }
    }
}
