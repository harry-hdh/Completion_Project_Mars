using NUnit.Framework.Legacy;
using OpenQA.Selenium.DevTools.V128.Audits;
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

        [Test]
        [TestCaseSource(nameof(AddInvalidEducation))]
        public void AddInvalidEducationTest(EducationModel educationModel)
        {
            PerformEducationAction(

                action: () => profileEduObj.AddEducation(_driver,
                                                    educationModel.UniName,
                                                    educationModel.UniCountry,
                                                    educationModel.Title,
                                                    educationModel.Degree,
                                                    educationModel.GraduationYear),
                educationModel: educationModel,
                actionName: "Add",
                assertType: "invalid"
            );
            //Fail as allows to add invalid characters
        }

        [Test]
        public void DeleteEducationTest()
        {
            profileEduObj.DeleteEducation(_driver);

            Assert.That(profileEduObj.GetNotiTxt(_driver).Contains("removed"), $"Failed to remove Education!");
        }

        private void PerformEducationAction(Action action, EducationModel educationModel, string actionName, string assertType = "default")
        {
            // Act
            action();

            // Assert
            switch (assertType)
            {   
                case "default":
                    Assert.That(profileEduObj.IsNotiDisplayed(_driver), Is.True, $"Failed to display notification on {actionName}!");
                    Assert.That(profileEduObj.GetDisplayedTxt(_driver, "uni Display").Equals(educationModel.UniName), $"Failed to {actionName} university name!");
                    Assert.That(profileEduObj.GetDisplayedTxt(_driver, "degree Display").Equals(educationModel.Degree), $"Failed to {actionName} degree!");
                    Assert.That(profileEduObj.GetDisplayedTxt(_driver, "title Display").Equals(educationModel.Title), $"Failed to {actionName} title!");
                    break;

                case "invalid":

                    if (profileEduObj.GetDisplayedTxt(_driver, "uni Display") == educationModel.UniName)
                    {
                        Assert.Fail($"Fail to validate {actionName} education");
                    }
                    //Assert.Pass();
                    break;

                default:
                    throw new NotImplementedException();

            }
        }

        public static IEnumerable<EducationModel> AddEducation()
            => LoadEducationData("ExampleEducation1.json");

        public static IEnumerable<EducationModel> AddInvalidEducation()
            => LoadEducationData("ExampleInvalidEducation.json");

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
