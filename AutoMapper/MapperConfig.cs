namespace AutoMapper
{
    public class MapperConfig
    {
        public static Mapper InitializeMapper<Tsource, Tdestination>()
        {
            var config = new MapperConfiguration(cfig =>
            {
                cfig.CreateMap<Tsource, Tdestination>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }

  
}
