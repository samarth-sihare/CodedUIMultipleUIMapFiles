using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CodedUIMultipleUIMapFiles.Pages_UIMaps.HomePage_UIMapClasses;
using CodedUIMultipleUIMapFiles.Pages_UIMaps.SignInPage_UIMapClasses;
using System.Diagnostics;


namespace CodedUIMultipleUIMapFiles
{

    /// <summary>
    /// Base Class
    /// </summary>
    [CodedUITest]
    public class CodedUITestBase
    {

        protected HomePage_UIMap homePage;
        protected BrowserWindow browser;

        //Use TestInitialize to run code before running each test 
        [TestInitialize]
        public void MyTestInitialize()
        {
            homePage = new HomePage_UIMap();

            string ApplicationUnderTestURL = ConfigurationManager.AppSettings["ApplicationUnderTestURL"].ToString();

            //BrowserWindow.CurrentBrowser = "Chrome";
            browser = BrowserWindow.Launch(new Uri(ApplicationUnderTestURL));
            browser.Maximized = true;

            //browser.ResizeWindow(200, 400);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestMethodCleanup()
        {
            Playback.Cleanup();
        }


        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }

}

