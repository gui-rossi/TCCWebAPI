using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCDomain.Entities
{
    public class UserHistoryEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("UserEntity")]
        public Guid User_Id { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        
        public virtual UserEntity User { get; set; } = new();

        [ForeignKey("ActionCategoryEntity")]
        public Guid Category_Id { get; set; }
        public virtual ActionCategoryEntity Action_Category { get; set; } = new();
    }
}
