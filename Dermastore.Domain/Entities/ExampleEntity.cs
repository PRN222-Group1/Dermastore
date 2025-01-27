namespace Dermastore.Domain.Entities
{
    public class ExampleEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required int GenderId { get; set; }
        public ExampleGender Gender { get; set; }
    }
}
