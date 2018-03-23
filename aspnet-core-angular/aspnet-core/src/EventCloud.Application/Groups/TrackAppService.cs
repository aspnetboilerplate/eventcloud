using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using EventCloud.Groups.Dto;
using EventCloud.Schedules;

namespace EventCloud.Groups
{
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
