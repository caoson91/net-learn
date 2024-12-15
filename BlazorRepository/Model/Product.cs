using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorRepository.Model
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime? ExpiredDate { get; set; } = default;

    }
}
