using OpenQA.Selenium;

namespace PlanItExtendReport.Page
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}