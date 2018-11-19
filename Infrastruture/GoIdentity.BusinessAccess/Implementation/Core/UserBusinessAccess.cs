using System.Linq;
using GoIdentity.Entities.Core;
using GoIdentity.Entities.Security;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.Utilities.Security;
using System.Collections.Generic;

namespace GoIdentity.BusinessAccess.Implementation.Core
{
    public class UserBusinessAccess : IUserBusinessAccess
    {
        private IUserDataAccess userDataAccess;

        public UserBusinessAccess(UserContext userContext, IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public List<Claim> ValidateUser(UserLoginLog userLoginLog, out User user)
        {
            //userLoginLog.Password = EncryptionManager.Encrypt(userLoginLog.Password);
            return this.userDataAccess.ValidateUser(userLoginLog, out user);
        }

        public List<Navigation> GetNavigationItems(int? userId = null)
        {
            return this.ToModuleFormat(this.userDataAccess.GetNavigationItems(userId));
        }
        

        private List<Navigation> ToModuleFormat(List<Navigation> navigationItemsList)
        {
            var modules = navigationItemsList.Where(n => n.ParentNavigationId == null).OrderBy(n => n.SortId).ToList();

            foreach (var module in modules)
            {
                module.ChildItems = navigationItemsList.Where(r => r.ParentNavigationId == module.NavigationId).OrderBy(r => r.SortId).ToList();
                if (module.ChildItems.Count > 0) module.hasChildren = true;

                foreach (var navigationGroup in module.ChildItems)
                {
                    navigationGroup.ChildItems = navigationItemsList.Where(r => r.ParentNavigationId == navigationGroup.NavigationId).OrderBy(r => r.SortId).ToList();
                    if (navigationGroup.ChildItems.Count > 0) navigationGroup.hasChildren = true;
                }
            }

            return modules;
        }

        public User Register(User user, string password)
        {
            return userDataAccess.Register(user, password);
        }

        public User GetUserProfile(int? userId = null)
        {
            return userDataAccess.GetUserProfile(userId);            
        }

        public List<UserScore> GetUserScores(int? userId = null)
        {
            return userDataAccess.GetUserScores(userId);
        }

        public bool UpdateUserProfile(User user)
        {
            return userDataAccess.UpdateUserProfile(user);
        }
    }
}
