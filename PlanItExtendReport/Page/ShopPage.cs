using System;

using OpenQA.Selenium;

using PlanItExtendReport.Util;



namespace PlanItExtendReport.Page
{
    public class ShopPage
    {


        public ShopPage()
        {
            driver = null;
        }

        public ShopPage(IWebDriver webdriver)
        {
            driver = webdriver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
         
            elementHelper = new ElementHelper(driver);
        }

        public IWebDriver driver;
        private ElementHelper elementHelper;

        public void AddItemToTheCart(string item)
        {
            string element = "//h4[contains(.,'" + item + "')]/following-sibling::p/a";
            elementHelper.GetElementByXPath(element).Click();
        }
    }
}
