using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiApp1.Models
{
    public class EventType
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Caption { get; set; }
        public string ColorCode { get; set; }
        [Ignore]
        public Color Color { get; set; }
    }
}
