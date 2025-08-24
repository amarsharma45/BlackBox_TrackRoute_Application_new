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
    public class ManageLoadService: IManageLoadService
    {
        private readonly IManageLoad _getLoadDetails;
        public ManageLoadService(IManageLoad getLoadDetails)
        {
            _getLoadDetails = getLoadDetails;
        }
        public List<LoadsDetails_dto> GetLoadData()
        {
            return _getLoadDetails.GetLoadData();
        }
        public LoadsDetailsById_dto GetLoadDataById(int loadId)
        {
            return _getLoadDetails.GetLoadDataById(loadId);
        }
        public void CreateOrUpdateLoad(LoadsDetailsById_dto loaddetails)
        {
            _getLoadDetails.CreateOrUpdateLoad(loaddetails);
        }
    }
}
