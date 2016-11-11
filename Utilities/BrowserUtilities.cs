using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
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

        ///<summary>
        ///Few methods for HTML Table
        ///</summary>
        ///
        private HtmlCell cellByStringContaining(int columnIndex, HtmlTable table, string cellText)
        {
            HtmlCell cell = new HtmlCell(table);
            cell.TechnologyName = "Web";
            cell.SearchProperties.Add(HtmlCell.PropertyNames.ColumnIndex, columnIndex.ToString());
            cell.SearchProperties.Add(HtmlCell.PropertyNames.FriendlyName, cellText, PropertyExpressionOperator.Contains);

            return cell;
        }

        private HtmlCell cellByRowColumnIndex(int rowIndex, int columnIndex, HtmlTable table)
        {
            HtmlCell cell = new HtmlCell(table);
            cell.TechnologyName = "Web";
            cell.SearchProperties.Add(HtmlCell.PropertyNames.RowIndex, rowIndex.ToString());
            cell.SearchProperties.Add(HtmlCell.PropertyNames.ColumnIndex, columnIndex.ToString());

            return cell;
        }

        private HtmlRow getRowContaining(string text, HtmlTable table)
        {
            HtmlRow row = new HtmlRow(table);
            row.SearchProperties.Add(HtmlRow.PropertyNames.InnerText, text, PropertyExpressionOperator.Contains);
            return row;
        }

        //This method can check a checkbox in a table that has certain string in its row
        //This method may be modified to get Table parameter accordingly
        public void checkCheckBoxWithStringInRow(string companyName, HtmlTable table)
        {
            HtmlCheckBox countryChkBox = new HtmlCheckBox(this.getRowContaining(companyName, table));

            if (countryChkBox.Checked == false)
                Mouse.Click(countryChkBox);

        }


    }
}
