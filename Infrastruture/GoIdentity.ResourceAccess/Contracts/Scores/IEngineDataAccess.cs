using GoIdentity.Entities.Scores;
using System.Collections.Generic;

namespace GoIdentity.ResourceAccess.Contracts.Scores
{
    public interface IEngineDataAccess
    {
        UserData GetUserDataForPull();
        void UpdateEngineResponse(List<EngineLogResponse> response);
    }
}
