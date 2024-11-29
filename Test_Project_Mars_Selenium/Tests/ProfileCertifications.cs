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
    internal class ProfileCertifications : Hooks
    {
        ProfileCertificationsPage profileCertObj = new ProfileCertificationsPage();

        [Test]
        [TestCaseSource(nameof(AddCert))]
        public void AddCertificationTest(CertificationModel certificationModel)
        {
            PerformEducationAction(
                action: () => profileCertObj.AddCert(_driver,
                                                certificationModel.CertName,
                                                certificationModel.From,
                                                certificationModel.AchieveYear),
                certificationModel: certificationModel,
                actionName: "Add"

            );
        }

        [Test]
        [TestCaseSource(nameof(EditCert))]
        public void EditCertificationTest(CertificationModel certificationModel)
        {
            PerformEducationAction(
                action: () => profileCertObj.EditCert(_driver,
                                                certificationModel.CertName,
                                                certificationModel.From,
                                                certificationModel.AchieveYear),
                certificationModel: certificationModel,
                actionName: "Edit"

            );
        }

        [Test]
        [TestCaseSource(nameof(AddInvalidCert))]
        public void AddInvalidCertificationTest(CertificationModel certificationModel)
        {
            PerformEducationAction(
                action: () => profileCertObj.AddCert(_driver,
                                                certificationModel.CertName,
                                                certificationModel.From,
                                                certificationModel.AchieveYear),
                certificationModel: certificationModel,
                actionName: "Add",
                assertType: "invalid"
            );
        }

        private void PerformEducationAction(Action action, CertificationModel certificationModel, string actionName, string assertType = "default")
        {
            // Act
            action();

            // Assert
            switch (assertType)
            {
                case "default":
                    Assert.That(profileCertObj.IsNotiDisplayed(_driver), Is.True, $"Failed to display notification on {actionName}!");
                    Assert.That(profileCertObj.GetDisplayedTxt(_driver, "award Display").Equals(certificationModel.CertName), $"Failed to {actionName} award name!");
                    Assert.That(profileCertObj.GetDisplayedTxt(_driver, "from Display").Equals(certificationModel.From), $"Failed to {actionName} award from!");
                    Assert.That(profileCertObj.GetDisplayedTxt(_driver, "year Display").Equals(certificationModel.AchieveYear), $"Failed to {actionName} year!");
                    break;

                case "invalid":
                    if(profileCertObj.GetDisplayedTxt(_driver, "award Display") == certificationModel.CertName && profileCertObj.GetDisplayedTxt(_driver, "from Display") == certificationModel.From)
                    {
                        Assert.Fail($"Fail to validate {actionName}");
                    }
                    //Assert.Pass();
                    break;

                default:
                    throw new NotImplementedException();
            }

        }

        public static IEnumerable<CertificationModel> AddCert()
            => LoadCertData("ExampleCertification1.json");

        public static IEnumerable<CertificationModel> AddInvalidCert()
            => LoadCertData("ExampleInvalidCertification.json");

        public static IEnumerable<CertificationModel> EditCert()
            => LoadCertData("ExampleCertification2.json");


        private static IEnumerable<CertificationModel> LoadCertData(string fileName)
        {
            foreach (var eduData in CustomReadJson.LoadJson<CertificationModel>(fileName))
            {
                yield return eduData;
            }
        }
    }
}
