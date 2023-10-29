using SQLite;

namespace DXMauiApp1.Models
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EventTypeId { get; set; }
        [Ignore]
        public object StatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsRepeat { get; set; }
        public bool AllDay { get; set; }
    }
}