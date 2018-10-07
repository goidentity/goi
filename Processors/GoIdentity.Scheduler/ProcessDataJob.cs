using GoIdentity.CoreEngine;
using GoIdentity.Entities.Core;
using GoIdentity.Entities.Scores;
using GoIdentity.ResourceAccess;
using GoIdentity.ResourceAccess.Implementation.Scores;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoIdentity.Scheduler
{
    public class ProcessDataJob : IJob
    {
        private static bool IsRunning = default(bool);

        public Task Execute(IJobExecutionContext context)
        {
            if (IsRunning) return default(Task);
            IsRunning = true;

            try
            {
                var userContext = new UserContext();
                var unitOfWork = new UnitOfWork(userContext);

                var engineDataAccess = new EngineDataAccess(unitOfWork, userContext);
                var userData = engineDataAccess.GetUserDataForPull();

                var response = new List<EngineLogResponse>();

                foreach (var item in userData.Influencers)
                {
                    foreach (var userInfluencer in userData.UserInfluencerAuths.Where(ui => ui.InfluencerId == item.InfluencerId).ToList())
                    {
                        var itemResponse = new EngineLogResponse
                        {
                            UserId = userInfluencer.UserId,
                            InfluencerId = (short)item.InfluencerId
                        };

                        try
                        {
                            switch (item.InfluencerId)
                            {
                                case ConnectorType.Undefined:
                                    break;
                                case ConnectorType.Google:
                                    var googleHandler = new GoogleHandler();
                                    itemResponse.Response = googleHandler.Handle(item, userInfluencer);
                                    itemResponse.PullStatus = "Success";
                                    break;
                                case ConnectorType.Twitter:
                                    var twitterHandler = new TwitterHandler();
                                    itemResponse.Response = twitterHandler.Handle(item, userInfluencer);
                                    itemResponse.PullStatus = "Success";
                                    break;
                                case ConnectorType.LinkedIn:
                                    break;
                                case ConnectorType.Upwork:
                                    break;
                                case ConnectorType.Naukri:
                                    break;
                                case ConnectorType.Payoneer:
                                    break;
                                case ConnectorType.Paisabazaar:
                                    break;
                                case ConnectorType.MCA:
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            itemResponse.Remarks = ex.ToString();
                            itemResponse.PullStatus = "Failed";
                        }
                        finally
                        {
                            itemResponse.TransactionDate = DateTime.Now;
                        }

                        response.Add(itemResponse);
                    }

                }

                engineDataAccess.UpdateEngineResponse(response);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsRunning = false;
            }

            return default(Task);
        }
    }
}
