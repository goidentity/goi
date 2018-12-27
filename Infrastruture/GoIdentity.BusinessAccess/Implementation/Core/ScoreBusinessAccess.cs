using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.BusinessAccess.Handlers;
using GoIdentity.Entities.Core;
using GoIdentity.Entities.Scores;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoIdentity.BusinessAccess.Implementation.Core
{
    public class ScoreBusinessAccess : IScoreBusinessAccess
    {
        private readonly IScoreDataAccess scoreDataAccess;

        public ScoreBusinessAccess(IScoreDataAccess scoreDataAccess)
        {
            this.scoreDataAccess = scoreDataAccess;
        }

        public List<vUserScore> GetLatestScoreByUserId(int userId)
        {
            var scores = this.scoreDataAccess.GetLatestScoreByUserId(userId);
            foreach (vUserScore score in scores.Where(s => s.ScoreType == "CurrentScore"))
            {
                var lastScore = scores.FirstOrDefault(s => s.IndustryId == score.IndustryId &&
                                                             s.CategoryId == score.CategoryId &&
                                                             s.ScoreType == "LastScore");
                score.LastScore = (lastScore != null) ? lastScore.Score : 0;
            }
            return scores.Where(s => s.ScoreType == "CurrentScore").ToList();
        }

        public List<UserNotification> GetNotifications(int userId)
        {
            return this.scoreDataAccess.GetNotifications(userId);
        }

        public List<ProfileScore> GetProfileScore(int userId)
        {
            return this.scoreDataAccess.GetProfileScore(userId);
        }

        public List<vUserToken> GetUserTokens(int userId)
        {
            return this.scoreDataAccess.GetUserTokens(userId);
        }

        public void Mock_RefreshScore(int userId)
        {
            /*
             * Get categories
             * Generate score for each category
             * */
            var categories = this.scoreDataAccess.GetCategories();
            var userScores = new List<UserScore>();
            var random = new Random();
            foreach(var category in categories)
            {
                var userScore = new UserScore();
                userScore.UserId = userId;
                userScore.ICMapId = category.Id;
                userScore.Score = random.Next(40, 100);
                var rndm_inner = new Random();
                var ionicScores = MockHelper.GetRandomValueCollection(rndm_inner, (double)userScore.Score, 3)
                    .OrderByDescending(o=>o);
                userScore.NeutralScore = (decimal)ionicScores.FirstOrDefault();
                userScore.PositiveScore = (decimal)ionicScores.Skip(1).FirstOrDefault();
                userScore.NegativeScore = (decimal)ionicScores.Skip(2).FirstOrDefault();
                userScores.Add(userScore);
            }
            this.scoreDataAccess.UpdateUserScore(userScores);
        }

        public void RefreshScore(int userId)
        {
            //Get tokens
            var userTokens = this.GetUserTokens(userId);
            var googleHandler = new GoogleHandler();

            var tokenValues = userTokens.Select(ut => ut.Token).Distinct().ToList();
            var tokenResponses = new Dictionary<string, string>();

            var tokenResponsesLinks = new Dictionary<string, GoogleData>();

            foreach (var token in tokenValues)
            {
                var response = googleHandler.RawHandle(token);
                tokenResponses.Add(token, response);

                var jObject = JObject.Parse(response);
                var itemsList = jObject["items"] as JArray;

                foreach (var item in itemsList)
                {
                    var link = item["link"].ToString();

                    var description = item["pagemap"]["metatags"][0]["og:description"];

                    if (description == null)
                    {
                        continue;
                    }

                    if (tokenResponsesLinks.ContainsKey(link))
                    {
                        tokenResponsesLinks[link].Count += 1;
                        tokenResponsesLinks[link].Description = description.ToString();
                    }
                    else
                    {
                        tokenResponsesLinks.Add(link,
                            new GoogleData
                            {
                                Link = link,
                                Count = 1,
                                Description = description.ToString()
                            });
                    }
                }
            }

            foreach (var key in tokenResponsesLinks.Keys)
            {
                var handlerData = googleHandler.ProcessDetailed(tokenResponsesLinks[key].Description);

                var gObject = default(JObject);
                var tokens = new List<string>();
                var score = default(double);
                var magnitude = default(double);

                tokenResponsesLinks[key].AnalyzeEntities = handlerData.AnalyzeEntities;
                gObject = JObject.Parse(tokenResponsesLinks[key].AnalyzeEntities);
                tokens = new List<string>();
                score = default(double);
                magnitude = default(double);

                foreach (var item in (gObject["Entities"] as JArray))
                {
                    tokens.Add(item["Name"].ToString());
                    score = score + (double.Parse(item["Sentiment"]["Score"].ToString()));
                    magnitude = magnitude + (double.Parse(item["Sentiment"]["Magnitude"].ToString()));
                }
                tokenResponsesLinks[key].AnalyzeEntitiesTokens = string.Join(",", tokens);
                tokenResponsesLinks[key].AnalyzeEntitiesScore = Math.Round(score / tokens.Count, 2);
                tokenResponsesLinks[key].AnalyzeEntitiesMagnitude = Math.Round(magnitude / tokens.Count, 2);

                tokenResponsesLinks[key].AnalyzeEntitySentiment = handlerData.AnalyzeEntitySentiment;
                gObject = JObject.Parse(tokenResponsesLinks[key].AnalyzeEntitySentiment);
                tokens = new List<string>();
                score = default(double);
                magnitude = default(double);

                foreach (var item in (gObject["Entities"] as JArray))
                {
                    tokens.Add(item["Name"].ToString());
                    score = score + (double.Parse(item["Sentiment"]["Score"].ToString()));
                    magnitude = magnitude + (double.Parse(item["Sentiment"]["Magnitude"].ToString()));
                }
                tokenResponsesLinks[key].AnalyzeEntitySentimentTokens = string.Join(",", tokens);
                tokenResponsesLinks[key].AnalyzeEntitySentimentScore = Math.Round(score / tokens.Count, 2);
                tokenResponsesLinks[key].AnalyzeEntitySentimentMagnitude = Math.Round(magnitude / tokens.Count, 2);

                tokenResponsesLinks[key].AnalyzeSyntax = handlerData.AnalyzeSyntax;
                gObject = JObject.Parse(tokenResponsesLinks[key].AnalyzeSyntax);
                tokens = new List<string>();
                score = default(double);
                magnitude = default(double);

                foreach (var item in (gObject["Sentences"] as JArray))
                {
                    tokens.Add(item["Text"]["Content"].ToString());
                }
                tokenResponsesLinks[key].AnalyzeSyntaxTokens = string.Join(",", tokens);

                tokenResponsesLinks[key].ClassifyText = handlerData.ClassifyText;
                gObject = JObject.Parse(tokenResponsesLinks[key].ClassifyText);
                tokens = new List<string>();
                score = default(double);
                magnitude = default(double);

                foreach (var item in (gObject["Categories"] as JArray))
                {
                    tokens.Add(item["Name"].ToString());
                }
                tokenResponsesLinks[key].ClassifyTextTokens = string.Join(",", tokens);

            }

            var googleData = new List<GoogleData>();
            foreach (var item in tokenResponsesLinks)
            {
                googleData.Add(item.Value);
            }

            this.scoreDataAccess.UpdateUserTokenResponseDetail(new UserTokenResponse
            {
                UserId = userId,
                Token = "",
                ProcessDate = DateTime.Now,

                CreatedBy = 1,
                CreatedDate = DateTime.Now,

                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            }
            , googleData);

            System.Console.WriteLine(tokenResponsesLinks);

        }
    }
}
