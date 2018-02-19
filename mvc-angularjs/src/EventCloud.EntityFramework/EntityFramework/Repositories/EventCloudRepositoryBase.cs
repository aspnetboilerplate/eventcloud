using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace EventCloud.EntityFramework.Repositories
{
    public abstract class EventCloudRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EventCloudDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EventCloudRepositoryBase(IDbContextProvider<EventCloudDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class EventCloudRepositoryBase<TEntity> : EventCloudRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected EventCloudRepositoryBase(IDbContextProvider<EventCloudDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
