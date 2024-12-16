using Utils.Database.Repository;

namespace Utils.Database.EntityTypeBuilder
{
    public class Class2 : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // has one
        public Class1 Class1 { get; set; }
        public Guid Class1Id { get; set; }
    }

}
