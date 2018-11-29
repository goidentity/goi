using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.ResourceAccess.Implementation.Core
{
    public class ScoreDataAccess : DataAccess, IScoreDataAccess
    {

        public ScoreDataAccess(IUnitOfWork unitOfWork, UserContext userContext) : base(unitOfWork, userContext)
        {
            this.unitOfWork = unitOfWork;
            this.userContext = userContext;
        }

        public List<vUserScore> GetLatestScoreByUserId(int userId) => unitOfWork
                .GetIdentityDbContext()
                .ExecuteResultSet<vUserScore>("select * from Core.vUserScore where UserId = " + userId.ToString())
                .ToList();

        public List<ProfileScore> GetProfileScore(int userId)
        {
            var parmsCollection = new ParmsCollection();
            var result = this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<ProfileScore>("[Scores].[getProfileScore]",
                            parmsCollection
                            .AddParm("@userId", SqlDbType.Int, userId)).ToList();

            return result;
        }       

        public List<UserNotification> GetNotifications(int userId)
        {
            return this.unitOfWork.GetIdentityDbContext().UserNotifications.Where(n => n.UserId == userId).ToList();
        }

        public List<vUserToken> GetUserTokens(int userId)
        {
            return this.unitOfWork.GetIdentityDbContext()
                .ExecuteResultSet<vUserToken>("SELECT * FROM Cores.vUserTokenView WHERE UserId = @userId" + userId.ToString())
                .ToList();
        }

        public bool UpdateUserTokenResponse(IEnumerable<UserTokenResponse> tokenResponse)
        {
            var tokenResponseTableType = UserDefinedTableTypes.UserTokenResponseType;
            foreach(var item in tokenResponse)
            {
                tokenResponseTableType.Rows.Add(new object[]
                {
                    item.UserTokenResponseId,
                    item.UserId,
                    item.Token,
                    item.ProcessDate,
                    item.CreatedBy,
                    item.CreatedDate,
                    item.ModifiedBy,
                    item.ModifiedDate
                });
            }
            var parmsCollection = new ParmsCollection();
            this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<int>("",
                parmsCollection
               .AddParm("@userTokenResponse", SqlDbType.Structured, tokenResponseTableType, "[Scores].[userTokenResponseType]"));

            return true;
        }
        public bool UpdateUserTokenResponseDetail(IEnumerable<UserTokenResponseDetail> responseDetail)
        {
            var responseDetailType = UserDefinedTableTypes.UserTokenResponseDetail;
            foreach (var item in responseDetail)
            {
                responseDetailType.Rows.Add(new object[]
                {
                    item.UserTokenResponseDetailId,
                    item.UserTokenResponseId,
                    item.ProcessedDate,
                    item.ResponseDataFileName,
                    item.NlpEntitiesFileName,
                    item.NlpEntities,
                    item.NlpSentimentFileName,
                    item.NlpSentiment,
                    item.NlpSyntaxFileName,
                    item.NlpSyntax,
                    item.NlpClassifyFileName,
                    item.NlpClassify,
                    item.CreatedBy,
                    item.CreatedDate,
                    item.ModifiedBy,
                    item.ModifiedDate
                });
            }
            var parmsCollection = new ParmsCollection();
            this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<int>("",
                parmsCollection
               .AddParm("@userTokenResponseDetail", SqlDbType.Structured, responseDetailType, 
               "[Scores].[userTokenResponseDetailType]"));

            return true;
        }
    }
}
