using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Common;

namespace TVRS.Application.Services.Common
{
    public interface IValidator<in T> where T : IEntity
    {

    }
}
