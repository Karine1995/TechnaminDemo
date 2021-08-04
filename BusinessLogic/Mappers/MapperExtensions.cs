using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class MapperExtensions
    {
        public static TDest MapTo<TDest>(this object obj) => Mapper.Instance.Map<TDest>(obj);
    }
}
