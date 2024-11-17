using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test_Project_Mars_Selenium.Pages;

namespace Test_Project_Mars_Selenium
{
    public class Hooks
    {
        public IWebDriver driver;
        LoginPage logIn = new LoginPage();

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            driver.Manage().Window.Maximize();

            logIn.LoginAction(driver, "testing111@gmail.com", "123qweasd");
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}