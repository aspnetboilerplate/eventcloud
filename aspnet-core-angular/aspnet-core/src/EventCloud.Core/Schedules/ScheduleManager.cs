using Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    public class ScheduleManager : IScheduleManager
    {
        private readonly IRepository<Schedule, Guid> _scheduleRepository;

        public ScheduleManager(
            IRepository<Schedule, Guid> scheduleRepository
        )
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task CreateAsync(Schedule @schedule)
        {
            await _scheduleRepository.InsertAsync(@schedule);
        }
    }
}
