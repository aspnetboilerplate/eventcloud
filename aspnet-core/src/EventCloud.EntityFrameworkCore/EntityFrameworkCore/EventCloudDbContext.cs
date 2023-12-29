using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EventCloud.Authorization.Roles;
using EventCloud.Authorization.Users;
using EventCloud.MultiTenancy;
using EventCloud.Events;

namespace EventCloud.EntityFrameworkCore
{
    public class EventCloudDbContext : AbpZeroDbContext<Tenant, Role, User, EventCloudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

        public EventCloudDbContext(DbContextOptions<EventCloudDbContext> options)
            : base(options)
        {
        }
    }
}
