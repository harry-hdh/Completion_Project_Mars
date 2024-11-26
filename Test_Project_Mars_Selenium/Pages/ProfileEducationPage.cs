using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project_Mars_Selenium.Utilities;

namespace Test_Project_Mars_Selenium.Pages
{
    internal class ProfileEducationPage
    {
        private readonly By educationTab = By.XPath("//a[contains(text(), 'Education')]");

        private readonly By addNewEduBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");

        private readonly By addBtn = By.XPath("//input[contains(@value,'Add')]");

        private readonly By editEduBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]");

        private readonly By removeEduBtn = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]");

        private readonly By updateBtn = By.XPath("//input[contains(@value,'Update')]");


        private readonly By uniTxtBox = By.XPath("//input[contains(@placeholder,'University Name')]");

        private readonly By countryDropDown = By.Name("country");

        private readonly By titleDropDrown = By.Name("title");

        private readonly By degreeTxtBox = By.Name("degree");

        private readonly By yearDropDown = By.Name("yearOfGraduation");

        private By GetByLocation(string location)
        {
            return location switch
            {
                "uni Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"),
                "country Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"),
                "title Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"),
                "degree Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"),
                "year Display" => By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"),
                _ => throw new NotImplementedException()
            };
        }


        public void AddEducation(IWebDriver driver, string uniTxt, string countryOpt, string titleOpt, string degreeTxt, string yearOpt)
        {
            //Navigate to Education
            CustomMethods.Click(driver, educationTab, "wait_click");

            //Click Add New btn
            CustomMethods.Click(driver, addNewEduBtn, "wait_click");

            CustomMethods.ClearEnterText(driver, uniTxtBox, uniTxt);

            CustomMethods.SelectDropDown(driver, countryDropDown, countryOpt);

            CustomMethods.SelectDropDown(driver, titleDropDrown, titleOpt);

            CustomMethods.ClearEnterText(driver, degreeTxtBox, degreeTxt);

            CustomMethods.SelectDropDown(driver, yearDropDown, yearOpt);

            CustomMethods.Click(driver, addBtn, "just_click");
        }


        public void EditEducation(IWebDriver driver, string uniTxt, string countryOpt, string titleOpt, string degreeTxt, string yearOpt)
        {
            //Navigate to Education
            CustomMethods.Click(driver, educationTab, "wait_click");

            //Click edit btn
            CustomMethods.Click(driver, editEduBtn, "wait_click");

            CustomMethods.ClearEnterText(driver, uniTxtBox, uniTxt);

            CustomMethods.SelectDropDown(driver, countryDropDown, countryOpt);

            CustomMethods.SelectDropDown(driver, titleDropDrown, titleOpt);

            CustomMethods.ClearEnterText(driver, degreeTxtBox, degreeTxt);

            CustomMethods.SelectDropDown(driver, yearDropDown, yearOpt);

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
