using AutoItX3Lib;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {        
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        //[FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @type='radio']")]
        //private List<> IWebElements ServiceTypeOptions { get; set; }
        public static IList<IWebElement> ServiceTypeOption => GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='serviceType' and @type='radio']"));

        //Select the Location Type
        //[FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        //private IWebElement LocationTypeOption { get; set; }
        public static IList<IWebElement> LocationTypeOption => GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='locationType' and @type='radio']"));
       

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        //private IWebElement Days { get; set; }

        public static IList<IWebElement> Days => GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='Available' and @type='checkbox']"));

        //Storing the starttime
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        //private IWebElement StartTime { get; set; }
        public static IList<IWebElement> StartTime => GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='StartTime' and @type='time']"));

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Storing the Endtime
        public static IList<IWebElement> EndTime => GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='EndTime' and @type='time']"));

        //Click on Skill Trade option
        //[FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        //private IWebElement SkillTradeOption { get; set; }
        public static IList<IWebElement> SkillTradeOption => GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='skillTrades' and @type='radio']"));
        
        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        public static IWebElement SkillExch => GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        //[FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        //private IWebElement ActiveOption { get; set; }
        public static IList<IWebElement> ActiveOption => GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='isActive' and @type='radio']"));
        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }
              
        public static IWebElement WorkSample => GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));

        public static IWebElement Cancel => GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[11]/div/input[2]"));
        

        //Start Date Experiment

        private const string XpathToFind = "/html/body/div/div/div[1]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input";
        internal void EnterShareSkill()
        {
            //Define file where Data retrived
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkills");
            Thread.Sleep(2000);
            
            //Click Shares Skill button
            ShareSkillButton.Click();
            Thread.Sleep(1000);

            //Set Title data from Excel file
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Thread.Sleep(1000);

            //Set description data from Excel file
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Thread.Sleep(1000);

            //Select data from CategoryDropDown
            CategoryDropDown.Click();
            SelectElement oSelect = new SelectElement(CategoryDropDown);
            Thread.Sleep(1000);
            oSelect.SelectByValue("3");
            Thread.Sleep(1000);

            //Select Data from SubCategoryDropDown
            SubCategoryDropDown.Click();
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            Thread.Sleep(1000);
            SubCategory.SelectByValue("3");
            Thread.Sleep(1000);

            //Set Tag data from ExcelFile
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Thread.Sleep(1000);
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "Tags"));
            Thread.Sleep(1000);

            //Select Redio button for Servicetype
            for (int i=0; i<ServiceTypeOption.Count(); i++)
            {
                IWebElement local_redio = ServiceTypeOption[i];
                string value = local_redio.GetAttribute("value");

                if(value.Equals("1"))
                {
                    local_redio.Click();
                }
            }
            Thread.Sleep(2000);

            //Select Redio button for Location Type
            for(int i=0; i<LocationTypeOption.Count(); i++)
            {
                IWebElement local_redio = LocationTypeOption[i];
                string value = local_redio.GetAttribute("value");

                if(value.Equals("0"))
                {
                    local_redio.Click();
                }
            }
            Thread.Sleep(1000);

            //Select Start Date
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys("2022-01-20");
            Thread.Sleep(1000);

            //Select End Date
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys("2023-10-17");
            Thread.Sleep(3000);

            //Select Available days and Select Start time & EndTime

            for(int i=0; i<Days.Count();i++)
            {
                IWebElement Check_days = Days[i];
                IWebElement Start_time = StartTime[i];
                IWebElement End_time = EndTime[i];
                                
                string value = Check_days.GetAttribute("index");
                string sValue = Start_time.GetAttribute("index");
                string eValue = End_time.GetAttribute("index");
                if(value.Equals("0"))
                {
                    Check_days.Click();
                    Thread.Sleep(1500);

                    Start_time.SendKeys("05:20");
                    Thread.Sleep(1500);

                    End_time.SendKeys("14:20");
                    Thread.Sleep(1500);

                }
                else if (value.Equals("3"))
                {
                    Check_days.Click();
                    Thread.Sleep(1500);

                    Start_time.SendKeys("01:10");
                    Thread.Sleep(1500);

                    End_time.SendKeys("19:30");
                    Thread.Sleep(1500);
                }
                else if(value.Equals("5"))
                {
                    Check_days.Click();
                    Thread.Sleep(1500);

                    Start_time.SendKeys("10:10");
                    Thread.Sleep(1500);

                    End_time.SendKeys("16:35");
                    Thread.Sleep(1500);
                }
                else
                {
                    TestContext.WriteLine("invalid input");
                }
            }

            //Select Redio button for Skill Trade

            for(int i=0; i<SkillTradeOption.Count(); i++)
            {
                IWebElement Skill_Trade = SkillTradeOption[i];
                string value = Skill_Trade.GetAttribute("value");
                if(value.Equals("true"))
                {
                    Skill_Trade.Click();
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchangeData"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "SkillExchangeData"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "SkillExchangeData"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "SkillExchangeData"));
                    Thread.Sleep(1000);
                }
                else if(value.Equals("false"))
                {
                    Skill_Trade.Click();
                    Thread.Sleep(1000);
                    CreditAmount.SendKeys("3");
                    Thread.Sleep(1000);
                }
                else
                {
                    TestContext.WriteLine("invalid Data");
                }
            }
            //Add attachment
            Thread.Sleep(1000);
            WorkSample.Click();
            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            Thread.Sleep(1000);
            autoIT.Send(@"C:\Users\SANDY\Untitled.m");
            Thread.Sleep(1000);
            autoIT.Send("{Enter}");
            Thread.Sleep(1000);

            //Select Active or Deactive Redio Button
            for (int i = 0; i < ActiveOption.Count(); i++)
            {
                IWebElement Active_Option = ActiveOption[i];
                string value = Active_Option.GetAttribute("value");
                if(value.Equals("true"))
                {
                    Active_Option.Click();
                    Thread.Sleep(1000);
                }
            }

            //Click Save Button
            Save.Click();
            Thread.Sleep(3000);

        }
      
        internal void CancelSkill()
        {
            Thread.Sleep(2000);
            ShareSkillButton.Click();
            Thread.Sleep(5000);

            Cancel.Click();
            Thread.Sleep(1000);

        }

        internal void EditShareSkill()
        {
            //Define file where Data retrived
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkills");
            Thread.Sleep(2000);

           //Set Title data from Excel file
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(7, "Title"));
            Thread.Sleep(1000);

            //Set description data from Excel file
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Thread.Sleep(1000);

            //Select data from CategoryDropDown
            CategoryDropDown.Click();
            SelectElement oSelect = new SelectElement(CategoryDropDown);
            Thread.Sleep(1000);
            oSelect.SelectByValue("4");
            Thread.Sleep(1000);

            //Select Data from SubCategoryDropDown
            SubCategoryDropDown.Click();
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            Thread.Sleep(1000);
            SubCategory.SelectByValue("4");
            Thread.Sleep(1000);

            //Set Tag data from ExcelFile
            Tags.Clear();
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(7, "Tags"));
            Thread.Sleep(1000);
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(8, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(9, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(10, "Tags"));
            Thread.Sleep(1000);

            //Select Redio button for Servicetype
            for (int i = 0; i < ServiceTypeOption.Count(); i++)
            {
                IWebElement local_redio = ServiceTypeOption[i];
                string value = local_redio.GetAttribute("value");

                if (value.Equals("0"))
                {
                    local_redio.Click();
                }
            }
            Thread.Sleep(2000);

            //Select Redio button for Location Type
            for (int i = 0; i < LocationTypeOption.Count(); i++)
            {
                IWebElement local_redio = LocationTypeOption[i];
                string value = local_redio.GetAttribute("value");

                if (value.Equals("1"))
                {
                    local_redio.Click();
                }
            }
            Thread.Sleep(1000);

            //Select Start Date
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys("2025-01-21");
            Thread.Sleep(1000);

            //Select End Date
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys("2023-10-07");
            Thread.Sleep(3000);

            //Select Available days and Select Start time & EndTime

            for (int i = 0; i < Days.Count(); i++)
            {
                IWebElement Check_days = Days[i];
                IWebElement Start_time = StartTime[i];
                IWebElement End_time = EndTime[i];

                string value = Check_days.GetAttribute("index");
                string sValue = Start_time.GetAttribute("index");
                string eValue = End_time.GetAttribute("index");
                if (value.Equals("0"))
                {
                    Check_days.Click();
                    Thread.Sleep(1500);

                    Start_time.Clear();
                    Start_time.SendKeys("07:20");
                    Thread.Sleep(1500);

                    End_time.Clear();
                    End_time.SendKeys("15:25");
                    Thread.Sleep(1500);

                }
                else if (value.Equals("4"))
                {
                    Check_days.Click();
                    Thread.Sleep(1500);

                    Start_time.SendKeys("01:10");
                    Thread.Sleep(1500);

                    End_time.SendKeys("19:30");
                    Thread.Sleep(1500);
                }
                else if (value.Equals("6"))
                {
                    Check_days.Click();
                    Thread.Sleep(1500);

                    Start_time.SendKeys("10:10");
                    Thread.Sleep(1500);

                    End_time.SendKeys("16:35");
                    Thread.Sleep(1500);
                }
                else
                {
                    TestContext.WriteLine("invalid input");
                }
            }

            //Select Redio button for Skill Trade

            for (int i = 0; i < SkillTradeOption.Count(); i++)
            {
                IWebElement Skill_Trade = SkillTradeOption[i];
                string value = Skill_Trade.GetAttribute("value");
                if (value.Equals("true"))
                {
                    Skill_Trade.Click();
                    Thread.Sleep(1000);
                    SkillExchange.Clear();
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(7, "SkillExchangeData"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(8, "SkillExchangeData"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(9, "SkillExchangeData"));
                    SkillExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(1000);
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(10, "SkillExchangeData"));
                    Thread.Sleep(1000);
                }
                else if (value.Equals("false"))
                {
                    Skill_Trade.Click();
                    Thread.Sleep(1000);
                    CreditAmount.Clear();
                    CreditAmount.SendKeys("4");
                    Thread.Sleep(1000);
                }
                else
                {
                    TestContext.WriteLine("invalid Data");
                }
            }
            //Add attachment
            Thread.Sleep(1000);
            WorkSample.Click();
            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("File Upload");
            Thread.Sleep(1000);
            autoIT.Send(@"C:\Users\SANDY\Untitled.m");
            Thread.Sleep(1000);
            autoIT.Send("{Enter}");
            Thread.Sleep(1000);

            //Select Active or Deactive Redio Button
            for (int i = 0; i < ActiveOption.Count(); i++)
            {
                IWebElement Active_Option = ActiveOption[i];
                string value = Active_Option.GetAttribute("value");
                if (value.Equals("true"))
                {
                    Active_Option.Click();
                    Thread.Sleep(2000);
                }
            }

            //Click Save Button
            Save.Click();
            Thread.Sleep(3000);

        }
    }
}

