using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Common;

namespace TVRS.Application.Extensions
{
    public static class MappingExtensions
    {
        public static T ConvertToDisplayDto<T>(this IEnumerable<T> entities, IMapper mapper) where T: IEntity
        {
            return mapper.Map<T>(entities);
        }
    }
}
