using System.Collections.Generic;

namespace mbill_blazor_admin.Models.Base.Page
{
    public class PagedDto<T>
    {
        public long Total { get; set; }
        public IReadOnlyList<T> Items { get; set; }
        public long Page { get; set; }
        public long Size { get; set; }

        public PagedDto()
        {
        }
        public PagedDto(IReadOnlyList<T> items)
        {
            Total = items.Count;
            Items = items;
        }
        public PagedDto(IReadOnlyList<T> items, long total) : this(items)
        {
            Total = total;
        }
    }
}
