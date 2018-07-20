using GoIdentity.Entities.Core;
using System;

namespace GoIdentity.ResourceAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IdentityDbContext _IdentityDb = default(IdentityDbContext);

        private UserContext userContext = default(UserContext);

        public UnitOfWork(UserContext userContext)
        {
            this.userContext = userContext;
        }
        
        public IdentityDbContext GetIdentityDbContext(bool createNew = false)
        {            
            if (null == _IdentityDb || createNew)
            {
                _IdentityDb = new IdentityDbContext();
            }

            return _IdentityDb;
        }

        public void ClearAll()
        {
            if (_IdentityDb != null) _IdentityDb.Dispose();
        }

        public void Dispose()
        {
            this.ClearAll();
        }
    }
}
