using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.Entities
{
    public class EventLogEntity : BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? LogType { get; set; }

        public int Status { get; set; }

        [MaxLength(100)]
        public string? Value { get; set; }

        public byte[]? ImgData { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
