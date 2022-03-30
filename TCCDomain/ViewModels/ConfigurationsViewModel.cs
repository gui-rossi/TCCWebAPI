using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.ViewModels
{
    public class ConfigurationsViewModel
    {
        public Guid id;

        public Guid user_id;

        public Guid recording_id;

        public bool isLampOn;

        public bool receive_notifications;

        public string battery_percentage;
    }
}
