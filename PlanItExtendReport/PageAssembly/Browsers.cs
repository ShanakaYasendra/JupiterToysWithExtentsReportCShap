﻿using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PlanItExtendReport.PageAssembly
{
    public class Browsers
    {
        private IWebDriver webDriver;
        private string baseURL;
        private string browser;



        public Browsers()
        {
            browser = "Chrome";
            baseURL = "https://jupiter.cloud.planittesting.com/";
        }



        public void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }


            Goto(baseURL);


        }



        public IWebDriver GetDriver()
        {
            return webDriver;
        }



        public string Title
        {
            get { return webDriver.Title; }
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }

        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
    }
}
