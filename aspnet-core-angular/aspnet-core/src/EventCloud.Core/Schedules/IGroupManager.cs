using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    using Abp.Domain.Services;

    public interface IGroupManager : IDomainService
    {
        Task CreateAsync(Group @group);
    }
}
