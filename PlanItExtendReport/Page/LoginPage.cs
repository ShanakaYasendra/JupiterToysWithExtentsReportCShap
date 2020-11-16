using OpenQA.Selenium;

namespace PlanItExtendReport.Page
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}