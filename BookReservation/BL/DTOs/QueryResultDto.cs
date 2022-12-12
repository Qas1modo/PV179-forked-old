using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class QueryResultDto<TEntity>
    {
        public int ItemsCount { get; set; }

        public int? PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool NextPageEmpty { get; set; }

        public bool PagingEnabled { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
