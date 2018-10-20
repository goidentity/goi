using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoIdentity.Entities.Core;
using GoIdentity.Entities.Scores;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.ResourceAccess.DataProcessors;

namespace GoIdentity.ResourceAccess.Implementation.Core
{
    public class AuthDataAccess : DataAccess, IAuthDataAccess
    {
        public AuthDataAccess(IUnitOfWork unitOfWork, UserContext userContext = null) : base(unitOfWork, userContext)
        {
            this.unitOfWork = unitOfWork;
            this.userContext = userContext;
        }

        public Influencer GetInfluncerAuthInfo(ConnectorType connectorType) => unitOfWork
            .GetIdentityDbContext()
            .Influencers
            .FirstOrDefault(inf => inf.InfluencerId == connectorType);

        public bool StoreAuthToken(UserInfluencerAuth userInfluencer)
        {
            var parameters = new ParmsCollection();
            parameters.AddParm("@userId", SqlDbType.Int, userInfluencer.UserId);
            parameters.AddParm("@influencerId", SqlDbType.Int, userInfluencer.InfluencerId);
            parameters.AddParm("@userName", SqlDbType.NVarChar, userInfluencer.UserName);
            parameters.AddParm("@secret", SqlDbType.NVarChar, userInfluencer.Secret);
            parameters.AddParm("@secret1", SqlDbType.NVarChar, userInfluencer.Secret1);
            parameters.AddParm("@secret2", SqlDbType.NVarChar, userInfluencer.Secret2);
            parameters.AddParm("@secret3", SqlDbType.NVarChar, userInfluencer.Secret3);
            parameters.AddParm("@other1", SqlDbType.NVarChar, userInfluencer.Other1);
            parameters.AddParm("@other2", SqlDbType.NVarChar, userInfluencer.Other2);

            int numOfRec = unitOfWork.GetIdentityDbContext().ExecuteNonQuery("Scores.UpdateAuthToken", parameters);
            if (numOfRec > 0)
                return true;
            else
                return false;
        }
        
    }
}
