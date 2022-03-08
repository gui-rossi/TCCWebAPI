using System.ComponentModel.DataAnnotations;

namespace TCCDomain.Entities
{
    public class ActionCategoryEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        public virtual UserHistoryEntity User_History { get; set; } = new ();
    }
}
