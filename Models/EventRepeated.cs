using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DXMauiApp1.Models
{
    public class EventRepeated
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Event))]
        public int EventId { get; set; }
        public int Frequency { get; set; }
        public int RepeatOn { get; set; }
        public string Weekdays { get; set; }
        public bool NeverFinish { get; set; }
        public int AfterOcurrencesFinish { get; set; }
        public DateTime DateOnFinish { get; set; }

        [OneToMany]
        public List<Event> Events { get; set; }
    }
}