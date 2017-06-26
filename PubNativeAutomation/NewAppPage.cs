using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PubNativeAutomation
{
   public class NewAppPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://dashboard.pubnative.net/apps/new");

        }

        public static CreateAppCommand CreateNewApp(string name)
        {
            return new CreateAppCommand(name);
        }
    }

    public class CreateAppCommand
    {
        private  string appIDname;
        private string nickName;
        private string keyword;
        private string category;

        public CreateAppCommand(string appIDname)
        {
            this.appIDname = appIDname;
        }

        public CreateAppCommand WithApplicationNickName(string nickName)
        {
            this.nickName = nickName;
            return this;
        }

        public CreateAppCommand WithKeywords(string keyword)
        {
            this.keyword = keyword;
            return this;
        }

      
        public CreateAppCommand WithCategory(string category)
        {
            this.category = category;
            return this;
        }

        public void Finish()
        {
            var appID = Driver.Instance.FindElement(By.Id("app_store_application_id"));
            appID.SendKeys(appIDname);

            var appNickname = Driver.Instance.FindElement(By.Id("app_title"));
            appNickname.SendKeys(nickName);


            var appCategory = Driver.Instance.FindElement(By.Id("app_main_category_id"));
            var selectElement = new SelectElement(appCategory);
            selectElement.SelectByText(category);

            var appKeywords = Driver.Instance.FindElement(By.Id("app_keywords"));
            appKeywords.Click();
            appKeywords.SendKeys(keyword);



            var finishButton = Driver.Instance.FindElement(By.Id("new-app-submit"));
            finishButton.Click();
           
           
        }
    }
}
