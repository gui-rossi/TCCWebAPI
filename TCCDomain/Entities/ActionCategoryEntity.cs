﻿using System.ComponentModel.DataAnnotations;

namespace TCCDomain.Entities
{
    public class ActionCategoryEntity : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        public virtual UserHistoryEntity User_History { get; set; } = new ();
    }
}
