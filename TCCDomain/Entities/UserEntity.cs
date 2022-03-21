using System.ComponentModel.DataAnnotations;

namespace TCCDomain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;        
        
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string? Name { get; set; } = string.Empty;

        [MaxLength(25)]
        public string? Cel { get; set; } = string.Empty;
        
        public int? Worker_Count { get; set; }

        public virtual ConfigurationsEntity Configurations { get; set; } = new();

        public virtual ICollection<UserHistoryEntity> User_History { get; set; }

        public virtual ICollection<DeviceLocationEntity> Device_Locations { get; set; }
    }
}
