using System;

using OpenQA.Selenium;

using PlanItExtendReport.Util;



namespace PlanItExtendReport.Page
{
    public class CartPage
    {
        private IWebDriver driver;
        private ElementHelper elementHelper;

        public CartPage()
        {
            driver = null;
        }

        public CartPage(IWebDriver webdriver)
        {
            driver = webdriver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        
            elementHelper = new ElementHelper(driver);
        }
        // Return cart item
        public bool GetItem(string item)
        {
            string xpathtext = "//td[contains(.,'" + item + "')]";


            return elementHelper.GetElementByXPath(xpathtext).Displayed;
    
        }
    }
}