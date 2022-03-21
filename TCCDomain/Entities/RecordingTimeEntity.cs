using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.Entities
{
    public  class RecordingTimeEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Starting_Time { get; set; }

        public DateTime Ending_Time { get; set; }

        public ConfigurationsEntity Configurations { get; set; } = new();
    }
}
