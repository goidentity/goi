using System.Collections.Generic;

namespace GoIdentity.Entities.Scores
{
    public class UserData
    {
        public List<Influencer> Influencers { get; set; }
        public List<UserInfluencerAuth> UserInfluencerAuths { get; set; }
    }
}
