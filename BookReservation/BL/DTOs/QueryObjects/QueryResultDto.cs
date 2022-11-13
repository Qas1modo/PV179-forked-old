using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.QueryObjects
{
    public class QueryResultDto<TDto>
    {
        public IEnumerable<TDto> Results { get; set; }
    }
}
