﻿using GoIdentity.Entities.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.ResourceAccess.Contracts.Core
{
    public interface IAuthDataAccess
    {
        Influencer GetInfluncerAuthInfo(ConnectorType connectorType);
        bool StoreAuthToken(UserInfluencerAuth userInfluencer);
    }
}
