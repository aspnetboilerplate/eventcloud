using System.Threading.Tasks;
using System;

namespace EventCloud.Groups
{
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Dto;
    using Schedules;

    [AbpAuthorize]
    public class GroupAppService : EventCloudAppServiceBase, IGroupAppService
    {
        private readonly IGroupManager _groupManager;
        private readonly IRepository<Group, Guid> _groupRepository;

        public GroupAppService(
            IGroupManager groupManager,
            IRepository<Group, Guid> groupRepository
        )
        {
            _groupManager = groupManager;
            _groupRepository = groupRepository;
        }

        public async Task CreateAsync(CreateGroupInput input)
        {
            var @group = Group.Create(input.ScheduleId, input.Time);
            await _groupManager.CreateAsync(@group);
        }
    }
}
