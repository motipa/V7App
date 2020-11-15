namespace ClubApp.Models.Common
{
    public abstract class ListQueryBase
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public string OrderBy { get; set; }
    }
}
