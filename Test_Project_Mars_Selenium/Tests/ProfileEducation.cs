using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project_Mars_Selenium.Pages;

namespace Test_Project_Mars_Selenium.Tests
{
    [TestFixture]
    internal class ProfileEducation : Hooks
    {
        ProfileEducationPage profileEduObj = new ProfileEducationPage();

        [Test]
        public void AddEducationTest()
        {
            profileEduObj.AddEducation(driver);
        }
    }
}
