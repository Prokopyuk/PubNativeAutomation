using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace PubNativeAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://dashboard.pubnative.net/apps/new");
            //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("name") == "email");
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

 

    public class LoginCommand
    {
        private readonly string userName;
        private  string password;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Name("email"));
            loginInput.SendKeys(userName);
            var passwordInput = Driver.Instance.FindElement(By.Name("password"));
            passwordInput.SendKeys(password);

            var rememberMenButton = Driver.Instance.FindElement(By.Id("remember-me"));
            rememberMenButton.Click();

            var loginButton = Driver.Instance.FindElement(By.Name("commit"));
            loginButton.Click();
        }
    }
}
