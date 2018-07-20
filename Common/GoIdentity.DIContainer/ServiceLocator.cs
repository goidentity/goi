using GoIdentity.BusinessAccess.Contracts.Core;
using GoIdentity.BusinessAccess.Implementation.Core;
using GoIdentity.Entities.Core;
using GoIdentity.ResourceAccess;
using GoIdentity.ResourceAccess.Contracts.Core;
using GoIdentity.ResourceAccess.Implementation.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GoIdentity.DIContainer
{
    public sealed class ServiceLocator
    {
        #region Variables
        private static ServiceLocator _Instance = default(ServiceLocator);
        private static Object _syncLock = new object();

        private IServiceCollection _serviceCollection = default(IServiceCollection);
        private IServiceProvider _serviceProvider = default(IServiceProvider);

        #endregion

        #region Constructor
        private ServiceLocator()
        {

        }
        #endregion

        #region Methods
        public void LoadContainer(IServiceCollection services)
        {
            /*
             * Transient: A new instance of the type is used every time the type is requested.
             * Scoped: A new instance of the type is created the first time it’s requested within a given HTTP request, and then re-used for all subsequent types resolved during that HTTP request.
             * Singleton: A single instance of the type is created once, and used by all subsequent requests for that type.
             */
            _serviceCollection = services;

            _serviceCollection.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            //Common
            _serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            //Data Access
            _serviceCollection.AddScoped<IUserDataAccess, UserDataAccess>();

            //Business Access
            _serviceCollection.AddScoped<IUserBusinessAccess, UserBusinessAccess>();

            _serviceCollection.AddScoped<UserContext, UserContext>();

            //Build Service Provider
            _serviceProvider = services.BuildServiceProvider();
        }

        public T Get<T>()
        {
            return this._serviceProvider.GetService<T>();
        }

        #endregion

        #region Properties
        public static ServiceLocator Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_Instance == null) _Instance = new ServiceLocator();
                }
                return _Instance;
            }
        }

        #endregion
    }
}