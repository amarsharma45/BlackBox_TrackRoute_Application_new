using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;
using TrackRoute_Application.Core.Interfaces;
using TrackRoute_Application.Services.Interface;

namespace TrackRoute_Application.Services.Implementation
{
    
    public class TruckService : ITruckService
    {
        private readonly IManageTruck _manageTruck;

        public TruckService(IManageTruck manageTruck)
        {
            _manageTruck = manageTruck;
        }
        public List<TruckDetails_dto> GetTruckData()
        {
           return _manageTruck.GetTruckData();
        }

        public TruckDetailsById_dto GetTruckDataById(int truckId)
        {
            return _manageTruck.GetTruckDataById(truckId);
        }
        public void CreateOrUpdateTruck(TruckDetailsById_dto loaddetails)
        {
            _manageTruck.CreateOrUpdateTruck(loaddetails);
        }
    }
}
