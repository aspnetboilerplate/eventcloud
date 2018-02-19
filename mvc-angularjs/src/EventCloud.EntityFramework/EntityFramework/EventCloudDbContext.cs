using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using EventCloud.Authorization.Roles;
using EventCloud.Events;
using EventCloud.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.EntityFramework
{
    public class EventCloudDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<EventRegistration> EventRegistrations { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public EventCloudDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in EventCloudDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of EventCloudDbContext since ABP automatically handles it.
         */
        public EventCloudDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public EventCloudDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
