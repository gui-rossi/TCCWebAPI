using System.ComponentModel.DataAnnotations.Schema;

namespace TCCDomain.Entities
{
    public class ConfigurationsEntity
    {
        [ForeignKey("UserEntity")]
        public int User_Id { get; set; }

        [ForeignKey("RecordingTimeEntity")]
        public int Recording_Id { get; set; }

        public bool IsLampOn { get; set; }

        public bool Receive_Notifications { get; set; }

        public string Battery_Percentage { get; set; } = string.Empty;

        public virtual UserEntity User { get; set; } = new();

        public virtual RecordingTimeEntity Recording_Time { get; set; } = new();
    }
}
