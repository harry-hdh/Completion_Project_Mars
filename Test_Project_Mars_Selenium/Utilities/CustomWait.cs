using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Test_Project_Mars_Selenium.Utilities
{
    public class CustomWait
    {
        public static void WaitToBeClickable(IWebDriver driver, By locator, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        //Wait for visiable
        public static void WaitToBeVisible(IWebDriver driver, By locator, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

        }

        public static void WaitAlertVisible(IWebDriver driver, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
    }
}
