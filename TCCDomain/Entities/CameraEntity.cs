using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.Entities
{
    public class CameraEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public string Date { get; set; }

        public bool IsViewed { get; set; }

    }
}
