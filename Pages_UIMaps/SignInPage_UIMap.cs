namespace CodedUIMultipleUIMapFiles.Pages_UIMaps.SignInPage_UIMapClasses
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


    public partial class SignInPage_UIMap
    {

        /// <summary>
        /// SignInToGoogleAccount - Use 'SignInToGoogleAccountParams' to pass parameters into this method.
        /// </summary>
        public SignInPage_UIMap SignInToGoogleAccount(string emailAddress, string password) 
        {
            #region Variable Declarations
            HtmlEdit enterYourEmailEdit = this.GoogleAccountSignInWindow.GoogleAccountSignInDocument.EnterYourEmailEdit;
            HtmlInputButton nextButton = this.GoogleAccountSignInWindow.GoogleAccountSignInDocument.NextButton;
            HtmlEdit passwordEdit = this.GoogleAccountSignInWindow.GoogleAccountSignInDocument.PasswordEdit;
            HtmlInputButton signInButton = this.GoogleAccountSignInWindow.GoogleAccountSignInDocument.SignInButton;
            #endregion

            // Type 'adsasd' in 'Enter your email' text box
            enterYourEmailEdit.Text = emailAddress;
            // Click 'Next' button
            Mouse.Click(nextButton);
            // Type '********' in 'Password' text box
            passwordEdit.Text = password;
            // Click 'Sign in' button
            Mouse.Click(signInButton);

            return this;
        }

        public void AssertErrorMesssage(string expectedErrorMessage)
        {
            #region Variable Declarations
            HtmlSpan passwordErrorMessage = this.GoogleAccountSignInWindow.GoogleAccountSignInDocument.PasswordErrorMessage;
            #endregion

            Assert.AreEqual(expectedErrorMessage, passwordErrorMessage.InnerText.Trim(), "The ErrorMessage is not as expected");
        }

    }


}
