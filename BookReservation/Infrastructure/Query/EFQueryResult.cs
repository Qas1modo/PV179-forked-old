using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class EFQueryResult<TEntity>
    {
        public long ItemsCount { get; }

        public int? PageNumber { get; }

        public int PageSize { get; }

        public bool PagingEnabled => PageNumber != null;

        public IEnumerable<TEntity> Items { get; }

        public EFQueryResult(IEnumerable<TEntity> items, long itemsCount, int pageSize = 20, int? requestedPageNumber = null)
        {
            this.Items = items;
            this.ItemsCount = itemsCount;
            this.PageNumber = requestedPageNumber;
            this.PageSize = pageSize;
        }
    }
}
