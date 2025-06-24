using System;
using System.Drawing;
using System.Windows.Forms;
using fitnesstrackerr;
using NUnit.Framework;
using System.Linq;

namespace DashboardTests
{
    [TestFixture]
    public class GoalProgressTests
    {
        [Test]
        public void DashboardDisplaysCorrectProgress_ForRunningActivity()
        {
            // Arrange
            string username = "uday123";
            string activity = "Running";
            double goalCalories = 500.0; // Goal set by user
            double burnedCalories = 375.0; // Retrieved from database

            // Act
            double progressPercent = CalculateProgressPercentage(burnedCalories, goalCalories);
            string progressColor = GetProgressColor(progressPercent);

            // Assert
            Assert.That(progressPercent, Is.EqualTo(75.0).Within(0.1), "Progress % should be accurate.");
            Assert.That(progressColor, Is.EqualTo("Yellow"), "Progress bar color should match percentage.");
        }

        // Method to calculate goal progress percentage
        private double CalculateProgressPercentage(double burned, double goal)
        {
            if (goal <= 0) return 0;
            return (burned / goal) * 100;
        }

        // Method to determine progress bar color based on percentage
        private string GetProgressColor(double percent)
        {
            if (percent >= 100) return "Green";
            else if (percent >= 50) return "Yellow";
            else return "Red";
        }
    }
}
