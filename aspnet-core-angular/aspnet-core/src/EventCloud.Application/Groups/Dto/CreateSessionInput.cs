using System;
using System.Collections.Generic;
using System.Text;

namespace EventCloud.Groups.Dto
{
    public class CreateSessionInput
    {
        public Guid GroupId { get; set; }

        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Location { get; set; }
    }
}
