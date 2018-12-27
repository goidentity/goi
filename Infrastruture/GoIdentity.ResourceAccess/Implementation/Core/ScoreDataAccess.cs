using GoIdentity.Entities.Core;
using GoIdentity.Entities.Scores;
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
                .ExecuteResultSet<vUserToken>($"SELECT * FROM [Core].vUserTokenView WHERE UserId = {userId}")
                .ToList();
        }

        public void RefreshScore(int userId)
        {

        }

        public bool UpdateUserTokenResponse(IEnumerable<UserTokenResponse> tokenResponse)
        {
            var tokenResponseTableType = UserDefinedTableTypes.UserTokenResponseType;
            foreach (var item in tokenResponse)
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

        public bool UpdateUserTokenResponseDetail(UserTokenResponse response, List<GoogleData> responseDetail)
        {
            var responseType = UserDefinedTableTypes.UserTokenResponseType;
            var responseDetailType = UserDefinedTableTypes.UserTokenResponseDetail;

            responseType.Rows.Add(new object[]
                {
                    response.UserTokenResponseId,
                    response.UserId,
                    response.Token,
                    response.ProcessDate,

                    response.CreatedBy,
                    response.CreatedDate,
                    response.ModifiedBy,
                    response.ModifiedDate
                });

            foreach (var item in responseDetail)
            {
                responseDetailType.Rows.Add(new object[]
                {
                    0,
                    0,
                    DateTime.Now,

                    item.Link,
                    item.Count,
                    item.Description,


                    item.AnalyzeEntities,
                    item.AnalyzeEntitiesTokens,
                    item.AnalyzeEntitiesScore,
                    item.AnalyzeEntitiesMagnitude,

                    item.AnalyzeEntitySentiment,
                    item.AnalyzeEntitySentimentTokens,
                    item.AnalyzeEntitySentimentScore,
                    item.AnalyzeEntitySentimentMagnitude,

                    item.AnalyzeSyntax,
                    item.AnalyzeSyntaxTokens,

                    item.ClassifyText,
                    item.ClassifyTextTokens
                });
            }
            var parmsCollection = new ParmsCollection();
            this.unitOfWork.GetIdentityDbContext(true).ExecuteStoredProcedure<int>("[Scores].updateUserTokenResponseDetail",
                parmsCollection
               .AddParm("@userTokenResponse", SqlDbType.Structured, responseType, "[Scores].[UserTokenResponseType]")
               .AddParm("@userTokenResponseDetail", SqlDbType.Structured, responseDetailType, "[Scores].UserTokenResponseDetailType"));

            return true;
        }
        

        public void UpdateUserScore(List<UserScore> userScores)
        {
            var groupId = Guid.NewGuid();
            var sql = @"INSERT INTO [Core].[trUserScore]
                                   ([UserId]
                                   ,[ICMapId]
                                   ,[ScoreType]
                                   ,[Score]
                                   ,[PositiveScore]
                                   ,[NeutralScore]
                                   ,[NegativeScore]
                                   ,[ChangeScore]
                                   ,[CreatedOn]
                                   ,[GroupId])
                             VALUES
                                   (@userId
                                   ,@icMapId
                                   ,NULL
                                   ,@score
                                   ,@positiveScore
                                   ,@neutralScore
                                   ,@negativeScore
                                   ,0
                                   ,GETDATE()
                                   ,@groupId)";

            foreach(var userScore in userScores)
            {
                var parameters = new ParmsCollection();
                parameters.AddParm("@userId", SqlDbType.Int, userScore.UserId);
                parameters.AddParm("@icMapId", SqlDbType.Int, userScore.ICMapId);
                parameters.AddParm("@score", SqlDbType.Decimal, userScore.Score);
                parameters.AddParm("@positiveScore", SqlDbType.Decimal, userScore.PositiveScore);
                parameters.AddParm("@neutralScore", SqlDbType.Decimal, userScore.NeutralScore);
                parameters.AddParm("@negativeScore", SqlDbType.Decimal, userScore.NegativeScore);
                parameters.AddParm("@groupId", SqlDbType.UniqueIdentifier, groupId);

                this.unitOfWork.GetIdentityDbContext(true)
                    .ExecuteNonQuery(sql, parameters, CommandType.Text);
            }
        }
        public List<Category> GetCategories()
        {
            return this.unitOfWork.GetIdentityDbContext(true).Categories.ToList();
        }
    }
}
