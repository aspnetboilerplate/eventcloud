using System;
using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    using Abp.Domain.Repositories;

    public class SessionManager : ISessionManager
    {
        private readonly IRepository<Session, Guid> _sessionRepository;

        public SessionManager(
            IRepository<Session, Guid> sessionRepository
        )
        {
            _sessionRepository = sessionRepository;
        }

        public async Task CreateAsync(Session @session)
        {
            await _sessionRepository.InsertAsync(@session);
        }
    }
}
