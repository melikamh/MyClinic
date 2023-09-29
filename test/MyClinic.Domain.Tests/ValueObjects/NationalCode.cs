using MyClinic.Domain.Errors;
using MyClinic.Domain.ValueObjects;
using NUnit.Framework;

namespace MyClinic.Domain.Tests.ValueObjects
{
    public class Tests
    {
        [Test]
        public void Create_ValidNationalCode_ShouldSucceed()
        {
            // Arrange
            string validNationalCode = "0794926215";

            // Act
            var result = NationalCode.Create(validNationalCode);

            // Assert
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Value, Is.EqualTo(validNationalCode));
        }

        [Test]
        public void Create_EmptyNationalCode_ShouldFail()
        {
            // Arrange
            string emptyNationalCode = "";

            // Act
            var result = NationalCode.Create(emptyNationalCode);

            // Assert
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Error, Is.EqualTo(DomainErrors.NationalCode.Empty));
        }

        [Test]
        public void Create_InvalidFormatNationalCode_ShouldFail()
        {
            // Arrange
            string invalidFormatNationalCode = "07aa926215";

            // Act
            var result = NationalCode.Create(invalidFormatNationalCode);

            // Assert
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Error, Is.EqualTo(DomainErrors.NationalCode.InvalidFormat));
        }

        [Test]
        public void Create_ShortFormatNationalCode_ShouldFail()
        {
            // Arrange
            string invalidFormatNationalCode = "22jj3";

            // Act
            var result = NationalCode.Create(invalidFormatNationalCode);

            // Assert
            Assert.That(result.IsFailure, Is.True);
            Assert.That(result.Error, Is.EqualTo(DomainErrors.NationalCode.Empty));
        }
    }
}