using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCDomain.ViewModels
{
    public class CameraVM
    {
        public int Id { get; set; }
        public string? Action { get; set; }
        public string? Date { get; set; }
        public bool IsViewed { get; set; }

    }
}
