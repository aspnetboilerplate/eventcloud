using Abp.Domain.Services;
using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    public interface ITrackManager : IDomainService
    {
        Task CreateAsync(Track @track);
    }
}
