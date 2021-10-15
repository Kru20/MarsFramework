using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        //[FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        //private IWebElement delete { get; set; }
        public static IWebElement delete => GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]"));
        public static IWebElement Yes => GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        internal void Listings()
        {
            manageListingsLink.Click();
            Thread.Sleep(3000);
            view.Click();
            Thread.Sleep(3000);


        }
        internal void EditSkills()
        {
            manageListingsLink.Click();
            Thread.Sleep(3000);
            edit.Click();
            ShareSkill s = new ShareSkill();
            s.EditShareSkill();
        }

        internal void DeleteSkills()
        {
            manageListingsLink.Click();
            Thread.Sleep(3000);
            delete.Click();
            Thread.Sleep(2000);
            Yes.Click();
            Thread.Sleep(2000);
        }
    }
}
