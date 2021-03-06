﻿using System;

using OpenQA.Selenium;

namespace PlanItExtendReport.Page
{
    public class NavBar
    {
        IWebDriver driver;
        public NavBar()
        {
            driver = null;
        }
        public NavBar(IWebDriver webdriver)
        {
            driver = webdriver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        
        }

            //Naviget to Contact Page
            public ContactPage GetContactPage()
        {
            driver.FindElement(By.LinkText("Contact")).Click();
            return new ContactPage(driver);

        }

        //Navigate to Home Page
        public HomePage GetHomePage()
        {
            driver.FindElement(By.LinkText("Home")).Click();
            return new HomePage(driver);
        }

        //Navigate to Shop Page
        public ShopPage GetShopPage()
        {
            driver.FindElement(By.LinkText("Shop")).Click();
            return new ShopPage(driver);
        }

        //Navigate to Cart Page
        public CartPage GetCartPage()
        {
            driver.FindElement(By.XPath("//a[@href='#/cart']")).Click();
            return new CartPage(driver);
        }

        //Navigate to Login Page
        public LoginPage GetLoginPage()
        {
            driver.FindElement(By.LinkText("Login")).Click();
            return new LoginPage(driver);
        }
    }
}
