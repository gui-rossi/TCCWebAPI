using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.Entities
{
    public  class RecordingTimeEntity : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Starting_Time { get; set; } = new DateTime(2022, 04, 01, 08, 00, 00); // 08:00:00 04/01/2022

        public DateTime Ending_Time { get; set; } = new DateTime(2022, 04, 01, 17, 00, 00); // 17:00:00 04/01/2022

        public ConfigurationsEntity Configurations { get; set; }
    }
}
