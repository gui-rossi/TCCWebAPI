using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCDomain.Entities
{
    public class DeviceLocationEntity
    {
        public int Id { get; set; }

        [ForeignKey("UserEntity")]
        public int? User_Id { get; set; }
        
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;

        public virtual UserEntity? User { get; set; } 
    }
}
