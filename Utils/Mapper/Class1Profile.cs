using Utils.Database.EntityTypeBuilder;

namespace Utils.Mapper
{
    public class Class1Profile : AutoMapper.Profile
    {
        public Class1Profile()
        {
            CreateMap<Class1, Class2>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
