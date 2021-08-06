namespace BLL.Mappers
{
    public static class MapperExtensions
    {
        public static TDest MapTo<TDest>(this object obj) => Mapper.Instance.Map<TDest>(obj);
    }
}
