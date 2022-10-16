using System;
using System.Threading.Tasks;
using GMV.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using AppContext = GMV.Models.AppContext;

namespace GMV.Tests
{
    public class RouteServiceTests
    {
        
        private readonly IRouteService _routeService;
        private readonly AppContext _dbContext;
        
        public RouteServiceTests()
        {
            _dbContext = GetDatabaseContext(); 
            _routeService = new RouteService(_dbContext);
        }
        
        
        private AppContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppContext(options);
            databaseContext.Database.EnsureCreatedAsync();
            return databaseContext;
        }
        
        [Fact]
        public async Task GetStopsList_Should_Return_All_Stops_When_Calling()
        {
            //Act
            var stops = await _routeService.GetStopsList();
            
            //Assert
            var length = stops.Count;
            Assert.NotNull(stops);
            Assert.Equal(36, length);
        }
        
        [Fact]
        public async Task GetNextStopTime_Should_Return_Future_Time_When_Calling_Stop_6041_At_855()
        {
            //Arrange
            var time = new DateTime(2022, 1, 1, 8, 55, 0);
            
            //Act
            var schedule = await _routeService.GetNextStopTime(6041, time);
            
            //Assert
            Assert.NotNull(schedule);
            Assert.Equal(900, schedule.Time);
        }
        
        [Fact]
        public async Task GetNextStopTime_Should_Return_Future_Time_When_Calling_Stop_6149_At_1115()
        {
            //Arrange
            var time = new DateTime(2022, 1, 1, 11, 15, 0);
            
            //Act
            var schedule = await _routeService.GetNextStopTime(6149, time);
            
            //Assert
            Assert.NotNull(schedule);
            Assert.Equal(1110, schedule.Time);
        }
        
        [Fact]
        public async Task GetNextStopTime_Should_Return_Null_When_Calling_Stop_6149_After_2300()
        {
            //Arrange
            // System works of Utc time so 5:30 am is 9:30 pm the day before 
            var time = new DateTime(2022, 1, 2, 05, 30, 0);
            
            //Act
            var schedule = await _routeService.GetNextStopTime(6149, time);
            
            //Assert
            Assert.Null(schedule);
        }
        
        [Fact]
        public async Task GetNextStopTime_Should_Return_Null_When_Calling_Stop_6041_After_2300()
        {
            //Arrange
            // System works of Utc time so 5:30 am is 9:30 pm the day before 
            var time = new DateTime(2022, 1, 2, 05, 30, 0);
            
            //Act
            var schedule = await _routeService.GetNextStopTime(6041, time);
            
            //Assert
            Assert.Null(schedule);
        }
        
        [Fact]
        public async Task GetNextStopTime_Should_Return_Default_When_Invalid_Stop_Is_Provided()
        {
            //Arrange

            
            //Act
            var schedule = await _routeService.GetNextStopTime(1, DateTime.UtcNow);
            
            //Assert
            Assert.Null(schedule);
        }
    }
}