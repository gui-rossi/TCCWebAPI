using System.ComponentModel.DataAnnotations.Schema;

namespace TCCDomain.Entities
{
    public class ConfigurationsEntity : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("UserEntity")]
        public Guid User_Id { get; set; }

        [ForeignKey("RecordingTimeEntity")]
        public Guid Recording_Id { get; set; }

        public bool IsLampOn { get; set; } = false;

        public bool Receive_Notifications { get; set; } = true;

        public string Battery_Percentage { get; set; } = "100%";

        public virtual UserEntity User { get; set; }

        public virtual RecordingTimeEntity Recording_Time { get; set; } = new();
    }
}
