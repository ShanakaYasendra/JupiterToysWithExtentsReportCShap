using System;

using NUnit.Framework;

using PlanItExtendReport.PageAssembly;

namespace PlanItExtendReport.Test
{
    public class ShoppingPageTest : BaseClass
    {
        [Test]
        public void AddingItemtoCartTest()
        {
            pages.navBar.GetShopPage();
            pages.shopPage.AddItemToTheCart("Funny Cow");
            pages.shopPage.AddItemToTheCart("Funny Cow");
            pages.shopPage.AddItemToTheCart("Bunny");

            pages.navBar.GetCartPage();

            Assert.IsTrue(pages.cartPage.GetItem("Funny Cow"));
            Assert.IsTrue(pages.cartPage.GetItem("Bunny"));

        }
    }
}
