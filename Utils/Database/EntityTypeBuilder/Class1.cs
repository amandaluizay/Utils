using Utils.Database.Repository;

namespace Utils.Database.EntityTypeBuilder
{
    internal class Class1 : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // has many
        public List<Class2> Class2s { get; set; }
    }

}
