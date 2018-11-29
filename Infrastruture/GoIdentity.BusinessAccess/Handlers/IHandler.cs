using Google.Cloud.Language.V1;
using GoIdentity.Entities.Scores;
using System.Threading.Tasks;

namespace GoIdentity.BusinessAccess.Handlers
{
    public interface IHandler
    {
        ConnectorType Connector { get; set; }

        string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey);

        string AuthorizeUser(Influencer influencer);

        Task<(string authToken, int expiresIn)> GetAuthToken(Influencer influencer, string authCode);
    }

    public abstract class Handler : IHandler
    {
        public ConnectorType Connector { get; set; }

        public Handler(ConnectorType connector)
        {
            this.Connector = connector;
        }

        public virtual string RawHandle(string input)
        {
            return string.Empty;
        }

        public virtual dynamic ProcessDetailed(string text)
        {
            return default(dynamic);
        }

        public virtual string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            return string.Empty;
        }

        public virtual string AuthorizeUser(Influencer influencer)
        {
            return string.Empty;
        }

        public virtual Task<(string authToken, int expiresIn)> GetAuthToken(Influencer influencer, string authCode)
        {
            return Task.FromResult((string.Empty,0));
        }
    }
}
