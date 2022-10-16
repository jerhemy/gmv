using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMV.Models;
using Microsoft.EntityFrameworkCore;
using AppContext = GMV.Models.AppContext;

namespace GMV.Services
{
    public class RouteService: IRouteService
    {
        private readonly AppContext _context;
        
        public RouteService(AppContext context)
        {
            _context = context;
        }
        
        public async Task<List<Stop>> GetStopsList()
        {
            return await _context.Stops.OrderBy(s => s.Name).ToListAsync();
        }
        
        public async Task<Schedule> GetNextStopTime(int stopId, DateTime time)
        {
            // Assume that we are always looking for Stop times relative to PST
            DateTime pacificTime = TimeZoneInfo.ConvertTimeFromUtc(time, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
            var now = Int32.Parse(pacificTime.ToString("HHmm"));

            return await _context.Schedules.FirstOrDefaultAsync(x => x.StopId == stopId && x.Time >= now);
        }
    }
}