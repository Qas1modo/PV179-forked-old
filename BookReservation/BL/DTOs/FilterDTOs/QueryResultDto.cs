using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.QueryObjects
{
    public class QueryResultDto<TEntity>
    {
        public long ItemsCount { get; }
        public int? PageNumber { get; }
        public int PageSize { get; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
