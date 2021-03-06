﻿using CarRent.Models.Vehicles;
using System.Collections.Generic;
using Xunit;
using Moq;
using CarRent.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarRent.ViewModels;

namespace CarRent.Tests.Controllers
{
    public class VehicleRepositoryTests
    {
        private Mock<IVehicleRepository> mockVehicleRepository;
        private VehiclesController controller;

        [Fact]
        public void Index_should_return_ViewResult()
        {
            //Arrange
            mockVehicleRepository = new Mock<IVehicleRepository>();
            controller = new VehiclesController(mockVehicleRepository.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
        }

        [Fact]
        public void Index_returns_view_with_all_vehicles()
        {
            //Arrange
            var cars = new List<Vehicle>
            {
                new Vehicle
                {
                    ID = 1,
                    MakeName = "Jeep",
                    ModelName = "Grand Cherokee",
                    RegistrationYear = 2005,
                    RegistrationCountry = "Estonia",
                    RegistrationNumber = "123abc"
                },
                new Vehicle
                {
                    ID = 2,
                    MakeName = "VW",
                    ModelName = "Golf",
                    RegistrationYear = 2006,
                    RegistrationCountry = "Estonia",
                    RegistrationNumber = "bazooka"
                }
            }.AsQueryable();

            mockVehicleRepository = new Mock<IVehicleRepository>();
            mockVehicleRepository.Setup(v => v.GetAllVehicles()).Returns(cars);
            controller = new VehiclesController(mockVehicleRepository.Object);

            //Act
            var result = Assert.IsType<ViewResult>(controller.Index());
            var model = Assert.IsAssignableFrom<IEnumerable<Vehicle>>
                (result.ViewData.Model);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Details_returns_view_by_ID()
        {
            //Arrange
            mockVehicleRepository = new Mock<IVehicleRepository>();
            mockVehicleRepository.Setup(v => v.GetVehicleByID(It.IsAny<int>())).Returns(new Vehicle{
                ID = 1,
                MakeName = "BMW",
                ModelName = "X6",
                RegistrationYear = 2017
            });

            controller = new VehiclesController(mockVehicleRepository.Object);

            //Act
            var result = Assert.IsType<ViewResult>(controller.Details(1));

            //Assert
            var model = Assert.IsType<Vehicle>(result.Model);
            Assert.Equal("BMW", model.MakeName);
        }

        [Fact]
        public void Create_returns_View()
        {
            //Arrange
            mockVehicleRepository = new Mock<IVehicleRepository>();
            controller = new VehiclesController(mockVehicleRepository.Object);

            //Act
            var result = controller.Create() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        //TODO: Create post test
        //TODO: Edit test
        //TODO: Edit post test
        //TODO: Delete test
        //TODO: Delete confirmed test
    }
}
