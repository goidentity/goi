using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Core;
using GoIdentity.Entities.Scores;
using GoIdentity.ResourceAccess.Contracts.Scores;

namespace GoIdentity.ResourceAccess.Implementation.Scores
{
    public class EngineDataAccess : DataAccess, IEngineDataAccess
    {
        public EngineDataAccess(IUnitOfWork unitOfWork, UserContext userContext) : base(unitOfWork, userContext)
        {
            this.unitOfWork = unitOfWork;
            this.userContext = userContext;
        }

        public UserData GetUserDataForPull()
        {
            var response = new UserData();

            response.Influencers = this.unitOfWork.GetIdentityDbContext().Influencers.ToList();
            response.UserInfluencerAuths = this.unitOfWork.GetIdentityDbContext().UserInfluencerAuths.ToList();

            var users = this.unitOfWork.GetIdentityDbContext().Users.ToList();
            foreach (var item in response.UserInfluencerAuths)
            {
                item.User = users.First(u => u.UserId == item.UserId);
            }

            return response;
        }

        public void UpdateEngineResponse(List<EngineLogResponse> response)
        {
            var engineResponseTable = UserDefinedTableTypes.EngineResponseType;

            foreach (var item in response)
            {
                engineResponseTable.Rows.Add(new object[]
                {
                    item.UserId,
                    item.InfluencerId,

                    item.PullStatus,
                    item.Response,
                    item.Remarks,
                    item.TransactionDate,
                });
            }

            var parmsCollection = new ParmsCollection();
            var result = this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<User>("[Scores].[updateEngineLogs]",
                            parmsCollection
                            .AddParm("@logs", SqlDbType.Structured, engineResponseTable, "[Scores].[EngineResponseType]")
                            ).FirstOrDefault();
        }
    }
}
