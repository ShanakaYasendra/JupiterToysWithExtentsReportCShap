using System;

using OpenQA.Selenium;

namespace PlanItExtendReport.Util
{
    public class ElementHelper
    {
        private IWebDriver driver;

        public ElementHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetElementByID(string element)
        {
            try
            {
                return driver.FindElement(By.Id(element));
            }
            catch(NoSuchElementException)
            {
                return null; 
            }

        }
        public IWebElement GetElementByClassName(string element)
        {
            try
            {
                return driver.FindElement(By.ClassName(element));
            }
            catch (NoSuchElementException)
            {
                return null;
            }

        }
        public IWebElement GetElementByCss(string element)
        {
            try
            {
                return driver.FindElement(By.CssSelector(element));
            }
            catch (NoSuchElementException)
            {
                return null;
            }

        }
        public IWebElement GetElementByXPath(string element)
        {
            try
            {
                return driver.FindElement(By.XPath(element));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public IWebElement GetElementByLinkText(string element)
        {
            try
            {
                return driver.FindElement(By.LinkText(element));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public IWebElement GetElementByName(string element)
        {
            try
            {
                return driver.FindElement(By.Name(element));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public IWebElement GetElementByTag(string element)
        {
            try
            {
                return driver.FindElement(By.TagName(element));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public IWebElement GetElementByPartialLinkText(string element)
        {
            try
            {
                return driver.FindElement(By.PartialLinkText(element));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        
    }
}