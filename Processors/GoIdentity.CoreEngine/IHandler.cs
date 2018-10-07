using GoIdentity.Entities.Scores;

namespace GoIdentity.CoreEngine
{
    public interface IHandler
    {
        ConnectorType Connector { get; set; }

        string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey);
    }

    public abstract class Handler : IHandler
    {
        public ConnectorType Connector { get; set; }

        public Handler(ConnectorType connector)
        {
            this.Connector = connector;
        }

        public virtual string Handle(Influencer influencer, UserInfluencerAuth userInfluencerAuthKey)
        {
            return "";
        }
    }
}
