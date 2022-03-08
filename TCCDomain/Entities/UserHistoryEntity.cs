using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCDomain.Entities
{
    public class UserHistoryEntity
    {
        public int Id { get; set; }

        public int User_Id { get; set; }
        
        [ForeignKey("ActionCategoryEntity")]
        public int Category_Id { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        
        public virtual UserEntity User { get; set; } = new();

        public virtual ActionCategoryEntity Action_Category { get; set; } = new();
    }
}
