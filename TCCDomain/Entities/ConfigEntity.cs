using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.Entities
{
    public class ConfigEntity : BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? ConfigLabel { get; set; }

        public bool Active { get; set; }

        [MaxLength(100)]
        public string? StartTime { get; set; }

        [MaxLength(100)]
        public string? EndTime { get; set; }
    }
}
