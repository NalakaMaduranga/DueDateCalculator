using DueDateCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DueDateCalculator.Test
{
    public class CalculateDateServiceTest
    {
        [Fact]
        public void CalculateEndDate_ReturnsCorrectEndDate()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 5, 1);
            int workingDays = 5;
            string expectedEndDate = "{\"endDate\":\"08/05/2023\"}";

            // Act
            var calculator = new CalculateDateService();
            string actualEndDate = calculator.CalculateEndDate(startDate, workingDays);

            // Assert
            Assert.Equal(expectedEndDate, actualEndDate);
        }

        [Fact]
        public void CalculateEndDate_ReturnsSameStartDate_WhenWorkingDaysIsZero()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 5, 1);
            int workingDays = 0;
            string expectedEndDate = "{\"endDate\":\"01/05/2023\"}";  // Start date should be the same as the end date

            // Act
            var calculator = new CalculateDateService();
            string actualEndDate = calculator.CalculateEndDate(startDate, workingDays);

            // Assert
            Assert.Equal(expectedEndDate, actualEndDate);
        }

        [Fact]
        public void CalculateEndDate_ReturnsEndDateIgnoringHolidays()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 5, 1);
            int workingDays = 7;
            string expectedEndDate = "{\"endDate\":\"10/05/2023\"}";  // Expected end date for the given inputs

            // Act
            var calculator = new CalculateDateService();
            string actualEndDate = calculator.CalculateEndDate(startDate, workingDays);

            // Assert
            Assert.Equal(expectedEndDate, actualEndDate);
        }
    }
}
