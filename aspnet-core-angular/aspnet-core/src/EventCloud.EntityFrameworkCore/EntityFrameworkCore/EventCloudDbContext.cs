using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;

namespace EventCloud.EntityFrameworkCore
{
    using Authorization.Roles;
    using Authorization.Users;
    using EventCloud.Speakers;
    using Events;
    using MultiTenancy;
    using Schedules;

    public class EventCloudDbContext : AbpZeroDbContext<Tenant, Role, User, EventCloudDbContext>
    {
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<Speaker> Speakers { get; set; }

        public EventCloudDbContext(DbContextOptions<EventCloudDbContext> options)
            : base(options)
        {
        }
    }
}
