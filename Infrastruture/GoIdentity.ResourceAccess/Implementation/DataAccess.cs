using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.Utilities.Constants;
using Newtonsoft.Json;
using System;
using System.Linq;
using GoIdentity.Utilities.Extensions;

namespace GoIdentity.ResourceAccess.Implementation
{
    public abstract class DataAccess
    {
        protected IUnitOfWork unitOfWork;
        protected UserContext userContext;
        private static object _syncObject = new object();

        public DataAccess(IUnitOfWork unitOfWork, UserContext userContext = null)
        {
            this.unitOfWork = unitOfWork;
            if (userContext != null) { this.userContext = userContext; }
        }

        protected void Log(string message = null, Exception ex = null)
        {
            Console.WriteLine(string.IsNullOrWhiteSpace(message) ? "Doesn't exists" : message);
            Console.WriteLine(ex == null ? "Doesn't exists" : ex.ToString());
        }
    }
}
