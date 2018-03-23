using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    using Abp.Domain.Services;

    public interface ISessionManager : IDomainService
    {
        Task CreateAsync(Session @session);
    }
}
