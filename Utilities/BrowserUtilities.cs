using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUIMultipleUIMapFiles
{
    class BrowserUtilities
    {

        public static BrowserWindow locateActiveBrowserTabByTitle(string tabTitle)
        {
            var browserTab = BrowserWindow.Locate(tabTitle);
            return browserTab;
        }

        //public static void locateActiveBrowserTabByTitle(string tabTitle)
        //{
        //    var browserTab = BrowserWindow.Locate(tabTitle);
        //}

        public static void activateTabByTitle(BrowserWindow browserWindow, string tabTitle)
        {
            WinTabList tablist = new WinTabList(browserWindow);
            var tabPages = new WinTabPage(tablist);
            var tabs = tabPages.FindMatchingControls();
            foreach (WinTabPage tab in tabs)
            {
                if (tab.Name.Contains(tabTitle))
                { 
                    Mouse.Click(tab);
                    break;
                }
            }
        }

        public static void closeBrowserTab(string tabTitle)
        {
            var browserTab = BrowserWindow.Locate(tabTitle);
            browserTab.Close();
        }

        /// <summary>
        /// This is faster way to close browser tab but only works for IE Browser
        /// </summary>
        /// <param name="tabTitle"></param>
        public static void closeIEBrowserWindowTab(string tabTitle)
        {
            var browserTab = BrowserWindow.Locate(tabTitle);
            WinButton close = new WinButton(browserTab);
            close.SearchProperties.Add(WinButton.PropertyNames.Name, "Close", PropertyExpressionOperator.Contains);
            Mouse.Click(close);
        }



    }
}
