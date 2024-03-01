using Experian_ChangeCalcService.Services;
using Experian_ChangeCalcService.Services.Contract;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experian_CalServiceTest
{
    public class ChangeCalculatorTests
    {
        [Fact]
        public void CalculateChange_ReturnsCorrectChange_WhenPurchaseAmountLessThanPaid()
        {
            // Arrange
            var mocker = new AutoMocker();
            var changeCalculator = mocker.CreateInstance<ChangeCalculatorService>();

            mocker.GetMock<IDenominationService>()
                .Setup(s => s.GetDenominations())
                .Returns(TestData.Denominations);

            // Act
            var change = changeCalculator.CalculateChange(20.0m, 100.0m);

            // Assert
            var expectedChange = new Dictionary<string, int>
            {
                { "£50", 1 },
                { "£20", 1 },
                { "£10", 1 }
                
            };

            Assert.Equal(expectedChange, change);
        }

        [Fact]
        public void CalculateChange_ThrowsException_WhenPurchaseAmountMoreThanPaid()
        {
            // Arrange
            var mocker = new AutoMocker();
            var changeCalculator = mocker.CreateInstance<ChangeCalculatorService>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => changeCalculator.CalculateChange(40.0m, 30.0m));
        }
    }
}
