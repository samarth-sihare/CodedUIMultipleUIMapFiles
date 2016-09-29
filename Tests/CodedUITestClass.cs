using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Data;


namespace CodedUIMultipleUIMapFiles
{
    /// <summary>
    /// Sample Coded UI Test Class
    /// </summary>


    [CodedUITest]
    public class CodedUITestClass : CodedUITestBase
    {

        //Make sure to save CSV data file as Unicode(UFT-8 without signature) - Codepage 65001 using File-->Advance Save Options...
        //Also rightclick on file-->properties and set "Copy to Output Directory" to always copy

        //Data Driven using csv file
        [TestMethod]
        [DeploymentItem("SearchData.xlsx")]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataFiles\\SearchData.xlsx;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "GoogleHomePage$", DataAccessMethod.Sequential)]
        public void GoogleSearch()
        {
            string searchText = TestContext.DataRow["Search Text"].ToString();
            homePage.GoogleSearch(searchText);

        }

        //Data Driven using excel (using custom methods for reading data from excel)
        [TestMethod]
        [DeploymentItem("LoginData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DataFiles\\LoginData.csv", "LoginData#csv", DataAccessMethod.Sequential)]
        public void GoogleLogin()
        {
            string user = TestContext.DataRow["Email"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            string expectedErrorMessage = TestContext.DataRow["ErrorMessage"].ToString();

            homePage.ClickSignInButton()
                .SignInToGoogleAccount(user, password)
                .AssertErrorMesssage(expectedErrorMessage);

            //Assertion
            //signInPage.AssertErrorMesssage(expectedErrorMessage);

        }

    }
}

