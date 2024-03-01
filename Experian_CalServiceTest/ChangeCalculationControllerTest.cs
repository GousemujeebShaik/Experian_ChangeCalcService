using Experian_ChangeCalcService.Controllers;
using Experian_ChangeCalcService.Models;
using Experian_ChangeCalcService.Services;
using Experian_ChangeCalcService.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experian_CalServiceTest
{
    public class ChangeCalculationControllerTest
    {
        [Fact]
        public void CalculateChange_ReturnsCorrectResult()
        {

            ///Used AutoMocker so that the dependencies will be auto resolved when creating the instance
            // Arrange
            var mocker = new AutoMocker();

            var denominationServiceMock = mocker.GetMock<IDenominationService>()
                .Setup(s => s.GetDenominations())
                .Returns(TestData.Denominations);

            var changeCalculatorServiceMock = mocker.GetMock<IChangeCalculatorService>()
                .Setup(s => s.CalculateChange(It.IsAny<decimal>(),It.IsAny<decimal>()))
                .Returns(TestData.CalculateChangeResponse);

            var changeCalculator = mocker.CreateInstance<ChangeCalculationController>();


            // Act
            var result = changeCalculator.CalculateChange(TestData.ChangeRequestModel) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var change = result.Value as Dictionary<string, int>;
            Assert.NotNull(change);

            var expectedChange = new Dictionary<string, int>
            {
                { "£50", 1 },
                { "£20", 1 },
                { "£10", 1 },
               
            };

            Assert.Equal(expectedChange, change);
        }

        [Fact]
        public void CalculateChange_ReturnsBadRequestForInsufficientAmount()
        {
            // Arrange
            var mocker = new AutoMocker();

            var denominationServiceMock = mocker.GetMock<IDenominationService>()
                .Setup(s => s.GetDenominations())
                .Returns(TestData.Denominations);

            var changeCalculatorServiceMock = mocker.GetMock<IChangeCalculatorService>()
                .Setup(s => s.CalculateChange(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(TestData.CalculateChangeResponse);

            var changeCalculator = mocker.CreateInstance<ChangeCalculationController>();
            // Act
            var result = changeCalculator.CalculateChange(TestData.ChangeRequestModelForException) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Insufficient Amount", result.Value);
        }
    }
}
