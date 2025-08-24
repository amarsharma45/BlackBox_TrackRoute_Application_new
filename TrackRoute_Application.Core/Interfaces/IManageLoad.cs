using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackRoute_Application.Core.DTO;

namespace TrackRoute_Application.Core.Interfaces
{
    public interface IManageLoad
    {
        List<LoadsDetails_dto> GetLoadData();
        LoadsDetailsById_dto GetLoadDataById(int loadId);
        void CreateOrUpdateLoad(LoadsDetailsById_dto loaddetails);
    }
}
