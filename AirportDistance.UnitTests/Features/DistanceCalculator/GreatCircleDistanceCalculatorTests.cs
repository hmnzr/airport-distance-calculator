using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDistance.Features.DistanceCalculator.Models;
using AirportDistance.Features.DistanceCalculator.Services;
using NUnit.Framework;

namespace AirportDistance.UnitTests.Features.DistanceCalculator
{
    [TestFixture]
    internal class GreatCircleDistanceCalculatorTests
    {
        [Test]
        public void CalculateGreatCircleDistance_ShouldReturnValidDistance_WhenValidCoordinates()
        {
            var ams = new Coordinates(52.309069, 4.763385);
            var msq = new Coordinates(53.85, 27.55);

            var target = new GreatCircleDistanceCalculator();
            var distance = target.CalculateGreatCircleDistance(ams, msq, DistanceUnit.Mile);

            Assert.AreEqual(947.5825726673833, distance.Distance);
            Assert.AreEqual(DistanceUnit.Mile, distance.Unit);
        }

        [Test]
        public void CalculateGreatCircleDistance_ShouldCalculateSameDistance_WhenFromToSwapped()
        {
            var bkk = new Coordinates(13.9125, 100.606667);
            var lax = new Coordinates(34.21016, -118.490169);

            var target = new GreatCircleDistanceCalculator();
            var distance = target.CalculateGreatCircleDistance(bkk, lax, DistanceUnit.Mile);
            var distanceBack = target.CalculateGreatCircleDistance(lax, bkk, DistanceUnit.Mile);

            Assert.AreEqual(distance, distanceBack);
        }

        [Test]
        public void CalculateGreatCircleDistance_ThrowsException_WhenUnsupportedUnitProvided()
        {
            var ams = new Coordinates(52.309069, 4.763385);
            var msq = new Coordinates(53.85, 27.55);

            var target = new GreatCircleDistanceCalculator();
            Assert.Throws<NotSupportedException>(() => target.CalculateGreatCircleDistance(ams, msq, DistanceUnit.Kilometer));
        }
    }
}
