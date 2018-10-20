using GoIdentity.Entities.Scores;
using System.Collections.Generic;

namespace GoIdentity.BusinessAccess.Handlers
{
    public class HandlerContainer
    {
        IDictionary<ConnectorType, IHandler> handlers = new Dictionary<ConnectorType, IHandler>();
        public HandlerContainer()
        {
            handlers.Add(ConnectorType.Google, new GoogleHandler());
            handlers.Add(ConnectorType.Twitter, new TwitterHandler());
            handlers.Add(ConnectorType.LinkedIn, new LinkedInHandler());
            handlers.Add(ConnectorType.Facebook, new FacebookHandler());
        }

        public IHandler GetHandler(ConnectorType connectorType)
        {
            return handlers.ContainsKey(connectorType) ? handlers[connectorType] : null;
        }
    }
}
