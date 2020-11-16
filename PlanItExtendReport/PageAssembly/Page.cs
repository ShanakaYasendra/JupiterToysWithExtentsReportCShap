using System;

using PlanItExtendReport.Page;

namespace PlanItExtendReport.PageAssembly
{
    public class Page
    {
        public Page(Browsers browsers)
        {
            _browser = browsers;
        }
        Browsers _browser
        {
            get;
        }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.getDriver);
       
            return page;
        }
        public ShopPage shopPage => GetPages<ShopPage>();
        public NavBar navBar => GetPages<NavBar>();
        public CartPage cartPage => GetPages<CartPage>();
        public ContactPage contactPage => GetPages<ContactPage>();
    }
}
