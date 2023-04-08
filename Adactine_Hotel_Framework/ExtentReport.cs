using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactine_Hotel_Framework
{
    public class ExtentReport : BaseClass
    {
        public static ExtentHtmlReporter extentReporter = new ExtentHtmlReporter(path); 
        public static ExtentReports report = new ExtentReports();
        public static ExtentTest parent;
        public static ExtentTest child;

        public static void Parent_Log(string parentNode)
        {
            parent = report.CreateTest(parentNode);
        }

        public static void Child_Log(string childNode) 
        {
            child = parent.CreateNode(childNode);
        }
        public static void Report_Log(string detailname, string filename)
        {
            TakeScreenShot(filename);
            child.Log(Status.Pass, detailname, MediaEntityBuilder.CreateScreenCaptureFromPath(path + filename).Build());
        }

        public static void Report()
        {
            report.AttachReporter(extentReporter);
        }
        public static void flush()
        {
            report.Flush();
        }
    }
}
