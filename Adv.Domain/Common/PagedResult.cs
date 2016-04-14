using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adv.Domain.Common
{
    public class PagedResult<TEntity>
    {
        IEnumerable<TEntity> _items;
        int _totalCount;
        int _pageSize;
        public PagedResult(IEnumerable<TEntity> items, int pageSize, int totalCount)
        {
            _items = items;
            _totalCount = totalCount;
            _pageSize = pageSize;
        }

        public IEnumerable<TEntity> Items { get { return _items; } }
        public int TotalCount { get { return _totalCount; } }

        public int PageSize {  get { return _pageSize; } }
    }
}
