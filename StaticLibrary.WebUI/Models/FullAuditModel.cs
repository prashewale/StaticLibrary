using System.ComponentModel.DataAnnotations;

namespace StaticLibrary.WebUI.Models
{
    public class FullAuditModel
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
