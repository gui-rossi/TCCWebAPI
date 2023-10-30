using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.ViewModels
{
    public class ConfigViewModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? ConfigLabel { get; set; }

        public bool Active { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
