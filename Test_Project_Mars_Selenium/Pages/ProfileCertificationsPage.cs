using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project_Mars_Selenium.Utilities;

namespace Test_Project_Mars_Selenium.Pages
{
    internal class ProfileCertificationsPage
    {
        private readonly By certificationTab = By.XPath("//a[contains(text(), 'Certifications')]");

        private readonly By addNewEduBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");

        private readonly By addBtn = By.XPath("//input[contains(@value,'Add')]");

        private readonly By addCertBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");

        private readonly By editCertBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]");

        private readonly By updateBtn = By.XPath("//input[contains(@value,'Update')]");


        private readonly By awardTxtBox = By.Name("certificationName");

        private readonly By certFromTxtBox = By.Name("certificationName");

        private readonly By certYearTxtBox = By.Name("certificationYear");

        private By GetByLocation(string location)
        {
            return location switch
            {
                "award Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"),
                "from Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"),
                "year Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"),
                
                _ => throw new NotImplementedException()
            };
        }


        public void AddCert(IWebDriver driver, string awardTxt, string fromTxt, string yearOpt)
        {
            //Navigate to Cert
            CustomMethods.Click(driver, certificationTab, "wait_click");

            //Click Add New btn
            CustomMethods.Click(driver, addNewEduBtn, "wait_click");

            CustomMethods.ClearEnterText(driver, awardTxtBox, awardTxt);

            CustomMethods.ClearEnterText(driver, certFromTxtBox, fromTxt);

            CustomMethods.SelectDropDown(driver, certYearTxtBox, yearOpt);

            CustomMethods.Click(driver, addBtn, "just_click");
        }

        public void EditEducation(IWebDriver driver, string awardTxt, string fromTxt, string yearOpt)
        {
            //Navigate to Education
            CustomMethods.Click(driver, certificationTab, "wait_click");

            //Click edit btn
            CustomMethods.Click(driver, addNewEduBtn, "wait_click");

            CustomMethods.ClearEnterText(driver, awardTxtBox, awardTxt);

            CustomMethods.ClearEnterText(driver, certFromTxtBox, fromTxt);

            CustomMethods.SelectDropDown(driver, certYearTxtBox, yearOpt);

            CustomMethods.Click(driver, updateBtn, "just_click");
        }

        public bool IsNotiDisplayed(IWebDriver driver)
        {
            return CustomMethods.getNotification(driver);
        }

        public string GetDisplayedTxt(IWebDriver driver, string location)
        {
            return CustomMethods.GetText(driver, GetByLocation(location));
        }
    }
}
