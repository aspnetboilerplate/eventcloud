using System;
using System.Threading.Tasks;

namespace EventCloud.Groups
{
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Dto;
    using Schedules;

    [AbpAuthorize]
    public class TrackAppService : EventCloudAppServiceBase, ITrackAppService
    {
        private readonly ITrackManager _trackManager;
        private readonly IRepository<Track, Guid> _trackRepository;

        public TrackAppService(
            ITrackManager trackManager,
            IRepository<Track, Guid> trackRepository
        )
        {
            _trackManager = trackManager;
            _trackRepository = trackRepository;
        }

        public async Task CreateAsync(CreateTrackInput input)
        {
            var track = Track.Create(input.SessionId, input.Title);
            await _trackManager.CreateAsync(@track);
        }
    }
}
