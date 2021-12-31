using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDistance.Exceptions;
using AirportDistance.Features.DistanceCalculator.Dtos;
using AirportDistance.Features.DistanceCalculator.Models;
using AirportDistance.Features.DistanceCalculator.Services;
using AirportDistance.Features.DistanceCalculator.Services.Interfaces;
using AirportDistance.Features.DistanceCalculator.UseCases;
using AirportDistance.Features.DistanceCalculator.Validators;
using Moq;
using NUnit.Framework;

namespace AirportDistance.UnitTests.Features.DistanceCalculator
{
    [TestFixture]
    internal class CalculateGreatCircleUseCaseTests
    {
        private Mock<ICTeleportClient> _clientMock;
        private CalculateGreatDistanceUseCase _target;

        [SetUp]
        public void SetUp()
        {
            _clientMock = new Mock<ICTeleportClient>();
            _target = new(_clientMock.Object, new GreatCircleDistanceCalculator(), new CalculateDistanceDtoValidator());
        }

        [Test]
        public async Task Execute_ShouldReturnDistance_WhenParametersCorrect()
        {
            _clientMock.Setup(it => it.GetAirportInfoAsync("AMS"))
                .ReturnsAsync(new AirportInfo("Netherlands", "AMS", "AMS", "Amsterdam", new(52.309069, 4.763385)));

            _clientMock.Setup(it => it.GetAirportInfoAsync("MSQ"))
                .ReturnsAsync(new AirportInfo("Belarus", "MSQ", "MSQ", "Minsk", new(53.85, 27.55)));

            var result = await _target.WithParameters(new CalculateDistanceDto("AMS", "MSQ")).Execute();
            Assert.NotNull(result);
        }

        [TestCase("AMS", "MSQQ")]
        [TestCase("London", "MSQ")]
        [TestCase("LAX", "")]
        [TestCase("", "LHR")]
        public void Execute_ShouldThrowValidationError_WhenParametersMissingOrInvalid(string from, string to)
        {
            var dto = new CalculateDistanceDto(from, to);

            Assert.ThrowsAsync<ValidationException>(async () => await _target.WithParameters(dto).Execute());
        }
    }
}
