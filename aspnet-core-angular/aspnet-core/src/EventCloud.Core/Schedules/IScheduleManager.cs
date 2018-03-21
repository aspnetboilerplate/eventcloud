using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    using Abp.Domain.Services;

    public interface IScheduleManager : IDomainService
    {
        Task CreateAsync(Schedule @event);
    }
}
