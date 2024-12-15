namespace BlazorRepository.Model
{
    public class Category : EntityBase
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; }
    }
}
