using System;
using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    using Abp.Domain.Repositories;

    public class GroupManager : IGroupManager
    {
        private readonly IRepository<Group, Guid> _groupRepository;

        public GroupManager(
            IRepository<Group, Guid> groupRepository
        )
        {
            _groupRepository = groupRepository;
        }

        public async Task CreateAsync(Group @group)
        {
            await _groupRepository.InsertAsync(@group);
        }
    }
}
