using System;

using NUnit.Framework;

using PlanItExtendReport.PageAssembly;

namespace PlanItExtendReport.Test
{
    public class ContactPageTest : BaseClass
    {
        [Test]
        public void ValidateMandatoryFields()
        {

            pages.navBar.GetContactPage();
            pages.contactPage.ClickSubmit();
        
            Assert.AreEqual(pages.contactPage.GetErrorMessage("forename"), "Forename is required");
            Assert.AreEqual(pages.contactPage.GetErrorMessage("email"), "Email is required");
            Assert.AreEqual(pages.contactPage.GetErrorMessage("message"), "Message is required");
            pages.navBar.GetHomePage();




        }
        ///<summary>
        ///     Test case 1.2:
        /// 1.	From the home page go to contact page
        /// 2.  Populate mandatory fields
        /// 3.	Validate errors are gone
        ///</summary>
        [Test]
        public void EnterValidDataToMandatoryFields()
        {

       pages.navBar.GetContactPage();
            pages.contactPage.Forename.SendKeys("John");
            Assert.IsFalse(pages.contactPage.IsErrorPresent("forename"));

            pages.contactPage.Email.SendKeys("John@test.com");
            Assert.IsFalse(pages.contactPage.IsErrorPresent("email"));

            pages.contactPage.Message.SendKeys("Hi How are You");
            Assert.IsFalse(pages.contactPage.IsErrorPresent("message"));

            pages.navBar.GetHomePage();

        }

        ///<summary>
        ///     Test case 2:
        /// 1.	From the home page go to contact page
        /// 2.	Populate mandatory fields
        /// 3.	Click submit button
        /// 4.	Validate successful submission message
        ///</summary>

        [Test]
        public void ValidDataToMandatoryFields()
        {

           pages.navBar.GetContactPage();
            pages.contactPage.EnterDataToMandatoryFields("Jim", "Jim@test.com", "Hi How are You");
            pages.contactPage.ClickSubmit();
            Assert.AreEqual(pages.contactPage.waitForModeltoClose(), "pass");
            Assert.AreEqual(pages.contactPage.SuccessMsg.Text, "Thanks Jim, we appreciate your feedback.");
            pages.navBar.GetHomePage();
        }
        ///<summary>
        ///     Test case 3:
        ///1.	From the home page go to contact page
        ///2.	Populate all fields with invalid data
        ///3.	Validate errors
        ///     Assumptions only Email field is validate for invalid data.
        ///     I have check mannually no validation for Forename and Message

        ///</summary>
        [Test]
        public void InvalidDataToAllFields()
        {


          pages.navBar.GetContactPage();
            pages.contactPage.EnterDataToAllFields("Shan123", "Jim@", "123SS", "Hi How are@@@@@34342533////// You");
            Assert.AreEqual(pages.contactPage.GetErrorMessage("email"), "Please enter a valid email");
            Assert.AreEqual(pages.contactPage.GetErrorMessage("telephone"), "Please enter a valid telephone number");
            pages.navBar.GetHomePage();

        }
    }
}
