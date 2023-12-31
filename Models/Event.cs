﻿using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DXMauiApp1.Models
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(EventType))]
        public int EventTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsRepeat { get; set; }
        public bool AllDay { get; set; }

        [ManyToOne]
        public EventType EventType { get; set; }

        [ManyToOne]
        public EventRepeated EventRepeated { get; set; }
    }
}