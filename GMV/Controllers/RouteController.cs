using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GMV.Models;
using GMV.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _service;
        
        public RouteController(IRouteService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Stop>> GetStops()
        {
            return await _service.GetStopsList();
        }
        
        [HttpGet("{stopId}")]
        public async Task<Schedule> GetTimes(int stopId)
        {
            return await _service.GetNextStopTime(stopId, DateTime.UtcNow);
        }
    }
}