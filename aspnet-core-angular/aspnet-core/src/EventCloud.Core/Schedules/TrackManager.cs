using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    public class TrackManager : ITrackManager
    {
        private readonly IRepository<Track, Guid> _trackRepository;

        public TrackManager(
            IRepository<Track, Guid> trackRepository
        )
        {
            _trackRepository = trackRepository;
        }

        public async Task CreateAsync(Track @track)
        {
            await _trackRepository.InsertAsync(@track);
        }
    }
}
