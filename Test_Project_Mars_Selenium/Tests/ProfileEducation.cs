using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project_Mars_Selenium.Pages;
using Test_Project_Mars_Selenium.Utilities;

namespace Test_Project_Mars_Selenium.Tests
{
    [TestFixture]
    
    internal class ProfileEducation : Hooks
    {
        ProfileEducationPage profileEduObj = new ProfileEducationPage();

        [Test]
        [TestCaseSource(nameof(AddEducation))]
        public void AddEducationTest(EducationModel educationModel)
        {
            PerformEducationAction(

                action: () => profileEduObj.AddEducation(_driver,
                                                    educationModel.UniName,
                                                    educationModel.UniCountry,
                                                    educationModel.Title,
                                                    educationModel.Degree,
                                                    educationModel.GraduationYear),
                educationModel: educationModel,
                actionName: "Add"
            );

        }


        [Test]
        [TestCaseSource(nameof(EditEducation))]
        public void EditEducationTest(EducationModel educationModel)
        {
            PerformEducationAction(
                action: () => profileEduObj.EditEducation(_driver, 
                                                    educationModel.UniName,
                                                    educationModel.UniCountry,
                                                    educationModel.Title,
                                                    educationModel.Degree,
                                                    educationModel.GraduationYear),
                educationModel: educationModel,
                actionName:"Edit"
            );


        }
        
        private void PerformEducationAction(Action action, EducationModel educationModel, string actionName)
        {
            // Act
            action();

            // Assert
            Assert.That(profileEduObj.IsNotiDisplayed(_driver), Is.True, $"Failed to display notification on {actionName}!");
            Assert.That(profileEduObj.GetDisplayedTxt(_driver, "uni Display").Equals(educationModel.UniName), $"Failed to {actionName} university name!");
            Assert.That(profileEduObj.GetDisplayedTxt(_driver, "degree Display").Equals(educationModel.Degree), $"Failed to {actionName} degree!");
            Assert.That(profileEduObj.GetDisplayedTxt(_driver, "title Display").Equals(educationModel.Title), $"Failed to {actionName} title!");
        }

        public static IEnumerable<EducationModel> AddEducation()
            => LoadEducationData("ExampleEducation1.json");

        public static IEnumerable<EducationModel> EditEducation()
            => LoadEducationData("ExampleEducation2.json");
        

        private static IEnumerable<EducationModel> LoadEducationData(string fileName)
        {
            foreach (var eduData in CustomReadJson.LoadJson<EducationModel>(fileName))
            {
                yield return eduData;
            }
        }
    }
}   
