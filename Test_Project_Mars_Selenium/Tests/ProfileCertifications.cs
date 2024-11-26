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
        public void AddProfileCerti(CertificationModel certificationModel)
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
        public void EditProfileCerti(CertificationModel certificationModel)
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

        private void PerformEducationAction(Action action, CertificationModel certificationModel, string actionName)
        {
            // Act
            action();

            // Assert
            Assert.That(profileCertObj.IsNotiDisplayed(_driver), Is.True, $"Failed to display notification on {actionName}!");
            Assert.That(profileCertObj.GetDisplayedTxt(_driver, "award Display").Equals(certificationModel.CertName), $"Failed to {actionName} award name!");
            Assert.That(profileCertObj.GetDisplayedTxt(_driver, "from Display").Equals(certificationModel.From), $"Failed to {actionName} award from!");
            Assert.That(profileCertObj.GetDisplayedTxt(_driver, "year Display").Equals(certificationModel.AchieveYear), $"Failed to {actionName} year!");
        }

        public static IEnumerable<CertificationModel> AddCert()
            => LoadCertData("ExampleCertification1.json");

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
