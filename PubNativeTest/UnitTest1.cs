using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PubNativeAutomation;

namespace PubNativeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void UserCanCreateNewApp()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("natali.prokopiuk@gmail.com")
                .WithPassword("Random1992")
                .Login();

            Assert.IsTrue(ReportsPage.IsAt,"Failed to login");

            NewAppPage.GoTo();
            NewAppPage.CreateNewApp("7654322")
                .WithApplicationNickName("DatingApp")
                .WithCategory("Dating")
                .WithKeywords("books")
                .Finish();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
