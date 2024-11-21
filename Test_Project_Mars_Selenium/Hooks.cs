using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test_Project_Mars_Selenium.Pages;

namespace Test_Project_Mars_Selenium
{
    public class Hooks
    {
        protected IWebDriver _driver;
        LoginPage logIn = new LoginPage();

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://localhost:5000/Home");
            _driver.Manage().Window.Maximize();

            logIn.LoginAction(_driver, "testing111@gmail.com", "123qweasd");
        }

        [TearDown]
        public void Close()
        {
            _driver.Close();
        }
    }
}