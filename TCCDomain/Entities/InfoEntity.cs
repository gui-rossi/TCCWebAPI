using System.ComponentModel.DataAnnotations;

namespace TCCDomain.Entities
{
    public class InfoEntity : BaseEntity
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Value { get; set; }
    }
}
