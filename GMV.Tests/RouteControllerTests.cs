using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMV.Controllers;
using GMV.Models;
using GMV.Services;
using Moq;
using Xunit;

namespace GMV.Tests
{
    public class RouteControllerTests
    {
        [Fact]
        public async Task Get_GetStops_Should_Call_GetStopsListOnce()
        { 
            Mock<IRouteService> mockRouteService = new Mock<IRouteService>();
            mockRouteService.Setup(x => x.GetStopsList()).ReturnsAsync(new List<Stop>() { new Stop() { Id = 1, Name = "test" } });
            
            var sut = new RouteController(mockRouteService.Object);

            var result = await sut.GetStops();

            mockRouteService.Verify(t => t.GetStopsList(), Times.Once);
        }
        
        [Fact]
        public async Task Get_GetStops_Result_Should_Return_List_Of_Stops()
        { 
            Mock<IRouteService> mockRouteService = new Mock<IRouteService>();
            mockRouteService.Setup(x => x.GetStopsList()).ReturnsAsync(new List<Stop>() { new Stop() { Id = 1, Name = "test" } });
            
            var sut = new RouteController(mockRouteService.Object);

            var result = await sut.GetStops();
            
            var length = result.ToList().Count;
            Assert.Equal(1, length);
        }
        
        [Fact]
        public async Task Get_GetTimes_Should_Call_GetNextStopTimeOnce()
        {
            Mock<IRouteService> mockRouteService = new Mock<IRouteService>();
            mockRouteService.Setup(x => x.GetNextStopTime(6041, It.IsAny<DateTime>())).ReturnsAsync( new Schedule() { Id = 1, Time = 900, StopId = 1});
            var sut = new RouteController(mockRouteService.Object);
            await sut.GetTimes(6041);
            mockRouteService.Verify(t => t.GetNextStopTime(6041, It.IsAny<DateTime>()), Times.Once);
        }
        
        [Fact]
        public async Task Get_GetTimes_Result_Should_NotBeNull()
        {
            Mock<IRouteService> mockRouteService = new Mock<IRouteService>();
            mockRouteService.Setup(x => x.GetNextStopTime(6041, It.IsAny<DateTime>())).ReturnsAsync( new Schedule() { Id = 1, Time = 900, StopId = 1});
            var sut = new RouteController(mockRouteService.Object);
            var result = await sut.GetTimes(6041);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(900, result.Time);
            Assert.Equal(1, result.StopId);
        }
        
        [Fact]
        public async Task Get_GetTimes_Result_Should_BeNull_If_Invalid_StopID()
        {
            Mock<IRouteService> mockRouteService = new Mock<IRouteService>();
            mockRouteService.Setup(x => x.GetNextStopTime(6041, It.IsAny<DateTime>())).ReturnsAsync( new Schedule() { Id = 1, Time = 900, StopId = 1});
            var sut = new RouteController(mockRouteService.Object);
            var result = await sut.GetTimes(1);
            Assert.Null(result);
        }
    }
}