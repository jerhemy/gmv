using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GMV.Models;

namespace GMV.Services
{
    public interface IRouteService
    {
        Task<List<Stop>> GetStopsList();
        Task<Schedule> GetNextStopTime(int stopId, DateTime time);
    }
}