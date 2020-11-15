using System;
using System.Collections.Generic;

namespace ClubApp.Models.Common
{
    public class GroupedLookupModel<TKey>
    {
        public string GroupLabel { get; set; }

        public IEnumerable<LookupModel<TKey>> Items { get; set; }
    }
}
