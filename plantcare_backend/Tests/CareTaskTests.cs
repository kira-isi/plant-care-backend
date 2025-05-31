using Domain.entities;
using Domain.valueObjects;
using Domain.valueObjects.careTaskDetails;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests
{
    public class CareTaskTests
    {
        [Fact]
        public void IsDue_ReturnsTrue_OneDayBeforeIntervalEnd()
        {
            // Arrange
            var lastPerformed = DateTime.Today.AddDays(-6); // Intervall 7 Tage
            var task = new RecurringCareTask(new Watering(), new WateringDetails(50), TimeSpan.FromDays(7), lastPerformed);

            // Act
            var isDue = task.IsDue();

            // Assert
            Assert.True(isDue);
        }

        [Fact]
        public void IsOverdue_ReturnsTrue_WhenIntervalPassed()
        {
            // Arrange
            var lastPerformed = DateTime.Today.AddDays(-8);
            var task = new RecurringCareTask(new Watering(), new WateringDetails(50), TimeSpan.FromDays(7), lastPerformed);

            // Act
            var isOverdue = task.IsOverdue();

            // Assert
            Assert.True(isOverdue);
        }

        [Fact]
        public void MarkAsPerformed_UpdatesLastPerformedToToday()
        {
            // Arrange
            var task = new RecurringCareTask(new Watering(), new WateringDetails(50), TimeSpan.FromDays(3), DateTime.Today.AddDays(-5));

            // Act
            task.MarkAsPerformed();

            // Assert
            Assert.Equal(DateTime.Today, task.LastPerformed);
        }
    }

}
