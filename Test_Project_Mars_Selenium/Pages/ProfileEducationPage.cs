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


        private readonly By uniTxtBox = By.XPath("//input[contains(@placeholder,'University Name')]");

        private readonly By countryDropDown = By.Name("country");

        private readonly By titleDropDrown = By.Name("title");

        private readonly By degreeDropDown = By.Name("degree");

        private readonly By yearDropDown = By.Name("yearOfGraduation");


        private readonly By uniDisplay = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]");

        private readonly By countryDisplay = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]");

        private readonly By titleDisplay = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]");

        private readonly By degreeDisplay = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]");

        private readonly By yearDisplay = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]");

        public void AddEducation(IWebDriver driver)
        {
            //Navigate to Education
            CustomMethods.Click(driver, educationTab, "wait_click");

            //Click Add New btn
            CustomMethods.Click(driver, addNewEduBtn, "wait_click");

        }
    }
}
