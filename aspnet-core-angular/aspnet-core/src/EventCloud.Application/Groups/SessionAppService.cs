using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using EventCloud.Groups.Dto;
using EventCloud.Schedules;

namespace EventCloud.Groups
{
    public class SessionAppService : EventCloudAppServiceBase, ISessionAppService
    {
        private readonly ISessionManager _sessionManager;
        private readonly IRepository<Session, Guid> _sessionRepository;

        public SessionAppService(
            ISessionManager sessionManager,
            IRepository<Session, Guid> sessionRepository
        )
        {
            _sessionManager = sessionManager;
            _sessionRepository = sessionRepository;
        }

        public async Task CreateAsync(CreateSessionInput input)
        {
            var @session = Session.Create(input.GroupId, input.Name, input.TimeStart, input.TimeEnd, input.Location);
            await _sessionManager.CreateAsync(@session);
        }
    }
}
