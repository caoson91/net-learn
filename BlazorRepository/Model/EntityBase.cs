using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorRepository.Model
{
    public class EntityBase<TPrimary>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPrimary Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }

    public class EntityBase : EntityBase<int>
    {

    }
}
