using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project_Mars_Selenium.Utilities
{
    public class CustomMethods
    {
        public static void Click(IWebDriver driver, By locator, string clickType)
        {
            switch (clickType)
            {
                case "just_click":
                    try
                    {
                        driver.FindElement(locator).Click();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;
                case "wait_click":
                    CustomWait.WaitToBeClickable(driver, locator, 15);
                    try
                    {
                        driver.FindElement(locator).Click();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static void ClearEnterText(IWebDriver driver, By locator, string text)
        {
            CustomWait.WaitToBeClickable(driver, locator, 15);
            var txtbox = driver.FindElement(locator);
            try
            {
                txtbox.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            txtbox.Clear();
            //might need another click
            txtbox.SendKeys(text);
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            var txtbox = driver.FindElement(locator);
            try
            {
                txtbox.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            txtbox.SendKeys(text);
        }

        public static void UploadFile(IWebDriver driver, By locator, string path)
        {
            driver.FindElement(locator).SendKeys(path);
            Thread.Sleep(1000);
        }

        public static void AcceptAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public static string GetText(IWebDriver driver, By locator)
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            IWebElement result = driver.FindElement(locator);

            return result.Text;
        }

        public static bool GetNotification(IWebDriver driver)
        {


            var popupXpath = By.XPath("//div[contains(@class, 'ns-box-inner')]");

            CustomWait.WaitToBeVisible(driver, popupXpath, 15);

            IWebElement result = driver.FindElement(popupXpath);

            return result.Displayed;
        }

        public static string GetNotificationTxt(IWebDriver driver)
        {


            var popupXpath = By.XPath("//div[contains(@class, 'ns-box-inner')]");

            CustomWait.WaitToBeVisible(driver, popupXpath, 15);

            IWebElement result = driver.FindElement(popupXpath);

            return result.Text;
        }

        public static void ClosePopUp(IWebDriver driver)
        {
            Click(driver, By.XPath("//a[@class='ns-close']"), "wait_click");
        }


        public static void SwitchToPopUp(IWebDriver driver, int frameNumber)
        {
            driver.SwitchTo().Frame(frameNumber);
        }

        public static void SwitchBackToDefault(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public static void SelectDropDown(IWebDriver driver, By locator, string value)
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            var dropdown = driver.FindElement(locator);
            var selectElement = new SelectElement(dropdown);

            selectElement.SelectByValue(value);
        }

        public static void CheckAndRemoveElement(IWebDriver driver, By locator, By removeLocator)
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            List<IWebElement> elements = new List<IWebElement>();

            elements.AddRange(driver.FindElements(locator));
            //Console.WriteLine(elements.Count());
            foreach (var _ in elements)
            {
                if (elements.Count > 0)
                {
                    driver.FindElement(removeLocator).Click();

                }
            }

        }

        public static void EnterRandomEmail(IWebDriver driver, By locator, string firstName, string lastname)
        {
            CustomWait.WaitToBeVisible(driver, locator, 10);
            var emailTxtbox = driver.FindElement(locator);

            Random random = new Random();

            int randomId = random.Next(0, 1000);

            try
            {
                emailTxtbox.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            emailTxtbox.SendKeys(firstName + "_" + lastname + randomId + "@gmail.com");
        }


    }
}
