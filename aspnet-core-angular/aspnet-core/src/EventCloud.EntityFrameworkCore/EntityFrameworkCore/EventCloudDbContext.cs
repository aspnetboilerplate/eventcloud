using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;

namespace EventCloud.EntityFrameworkCore
{
    using Authorization.Roles;
    using Authorization.Users;
    using Maps;
    using Speakers;
    using Events;
    using MultiTenancy;
    using Products;
    using Schedules;
    using Supports;
    using Abouts;

    public class EventCloudDbContext : AbpZeroDbContext<Tenant, Role, User, EventCloudDbContext>
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<Speaker> Speakers { get; set; }

        public virtual DbSet<Map> Maps { get; set; }

        public virtual DbSet<Support> Supports { get; set; }

        public virtual DbSet<About> Abouts { get; set; }

        public EventCloudDbContext(DbContextOptions<EventCloudDbContext> options)
            : base(options)
        {
        }
    }
}
