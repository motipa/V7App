using System;
namespace ClubApp.Models.Common
{
    public class LookupModel<TKey>
    {
        public TKey ValueMember { get; set; }

        public string DisplayMember { get; set; }
    }
}
