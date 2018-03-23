using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace EventCloud.Schedules
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppSession")]
    public class Session : FullAuditedEntity<Guid>
    {
        public Guid GroupId { get; set; }

        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Location { get; set; }
        
        public IEnumerable<Track> Tracks { get; set; }

        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Session()
        {

        }

        public static Session Create(Guid groupId, string name, string timeStart, string timeEnd, string location)
        {
            var @session = new Session
            {
                GroupId = groupId,
                Name = name,
                TimeStart = timeStart,
                TimeEnd = timeEnd,
                Location = location
            };

            return @session;
        }
    }
}
