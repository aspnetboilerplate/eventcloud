using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace EventCloud.Statistics
{
    public interface IStatisticsAppService : IApplicationService
    {
        Task<ListResultOutput<NameValueDto>> GetStatistics();
    }
}