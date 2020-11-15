using System.Collections.Generic;

namespace ClubApp.Models.Common
{
    public class ListQueryResult<TEntity>
    {
        public ListQueryResult(IEnumerable<TEntity> payload, int totalCount)
        {
            Payload = payload;
            TotalCount = totalCount;
        }

        public readonly IEnumerable<TEntity> Payload;

        public readonly int TotalCount;
    }
}
