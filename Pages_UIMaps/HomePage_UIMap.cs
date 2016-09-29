namespace CodedUIMultipleUIMapFiles.Pages_UIMaps.HomePage_UIMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    using CodedUIMultipleUIMapFiles.Pages_UIMaps.SignInPage_UIMapClasses;


    public partial class HomePage_UIMap
    {

        /// <summary>
        /// GoogleSearch - Use 'GoogleSearchParams' to pass parameters into this method.
        /// </summary>
        public void GoogleSearch(string searchText)
        {
            #region Variable Declarations
            HtmlEdit searchTextBox = this.GoogleBrowserWindow.GoogleDocument.SearchTextBox;
            HtmlButton SearchButton = this.GoogleBrowserWindow.GoogleDocument.SearchButton;
            #endregion

            // Type 'hello google' in 'Search' text box
            searchTextBox.Text = searchText;

            // Click pane
            Mouse.Click(SearchButton);
        }



        /// <summary>
        /// ClickSignInButton
        /// </summary>
        public SignInPage_UIMap ClickSignInButton()
        {
            #region Variable Declarations
            HtmlHyperlink signInHyperlink = this.GoogleBrowserWindow.GoogleDocument.SignInHyperlink;
            #endregion

            // Click 'Sign in' link
            Mouse.Click(signInHyperlink);

            return new SignInPage_UIMap();
        }
    }
    
}
