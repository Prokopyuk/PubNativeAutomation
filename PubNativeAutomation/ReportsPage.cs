using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PubNativeAutomation
{
    public class ReportsPage
    {
        public static bool IsAt
        {
            get
            {
                var h4s = Driver.Instance.FindElements(By.TagName("h4"));
                if (h4s.Count > 0)
                    return h4s[0].Text == "Payout";
                
                return false;
            }
           
        }
    }
}
