using BlogLib;
using System.ComponentModel.DataAnnotations;

namespace TestProject1
{
   
        [TestFixture]
        public class AdminInfoTesting
        {
            [Test]
            public void ValidAdmainInfo()
            {
                //Arrange
                var adminInfo = new AdminInfo
                {
                    EmailId = "surya@gmail.com",
                    Password = "surya@25"
                };
                // Act
                var validationContext = new ValidationContext(adminInfo, null, null);
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, true);
                // Assert
                Assert.IsTrue(isValid);
            }
            [Test]
            public void InvalidAdminInfo_MissingEmail_ShouldFailValidation()
            {
                // Arrange
                var adminInfo = new AdminInfo
                {
                    Password = "SecurePassword123"
                };

                // Act
                var validationContext = new ValidationContext(adminInfo, null, null);
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, false);

                // Assert
                Assert.IsFalse(isValid);
                Assert.AreEqual(1, validationResults.Count);
                Assert.AreEqual("The Email field is required.", validationResults[0].ErrorMessage);
            }

            [Test]
            public void InvalidAdminInfo_InvalidEmailFormat_ShouldFailValidation()
            {
                // Arrange
                var adminInfo = new AdminInfo
                {
                    EmailId = "su@@gm.com",
                    Password = "SecurePassword123"
                };

                // Act
                var validationContext = new ValidationContext(adminInfo, null, null);
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, false);

                // Assert
                Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
                Assert.AreEqual("The Email field is not a valid e-mail address.", validationResults[0].ErrorMessage);
            }

            // Add more test cases as needed for other scenarios.
        }


    }

