using AirportDistance.Features.DistanceCalculator.Models;

namespace AirportDistance.Features.DistanceCalculator.Services
{
    public class GreatCircleDistanceCalculator
    {
        private const double EarthRadiusInMiles = 3958.8;
        private readonly double Radian = Math.PI / 180;

        /// <summary>
        /// Calculates a great circle distance between two GPS points
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="unit">A desired unit to calculate the distance.</param>
        /// <returns>A distance in desired units</returns>
        public DistanceInfo CalculateGreatCircleDistance(Coordinates from, Coordinates to, DistanceUnit unit)
        {
            if (unit != DistanceUnit.Mile)
            {
                throw new NotSupportedException($"Unit conversion must be implemented to support {unit}.");
            }

            var latFromRadian = from.Latitude * Radian;
            var latToRadian = to.Latitude * Radian;
            var deltaLatRadian = (from.Latitude - to.Latitude) * Radian;
            var deltaLonRadian = (from.Longitude - to.Longitude) * Radian;

            var a = Math.Pow(Math.Sin(deltaLatRadian / 2), 2) +
                    Math.Cos(latFromRadian) * Math.Cos(latToRadian) *
                    Math.Pow(Math.Sin(deltaLonRadian / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distanceMiles = EarthRadiusInMiles * c;

            return new DistanceInfo(distanceMiles, unit);
        }
    }
}
