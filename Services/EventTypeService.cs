using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXMauiApp1.Models;
using SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DXMauiApp1.Services
{
    public class EventTypeService : BaseSQLiteService
    {
        public async Task<EventType> GetEventTypeById(int id)
        {
            await Init();
            var query = await db.Table<EventType>().FirstOrDefaultAsync(x => x.Id == id);

            return query;
        }
        public async Task<IEnumerable<EventType>> GetAllEventTypes()
        {
            await Init();
            var ls = await db.Table<EventType>().ToListAsync();
            foreach (var e in ls)
            {
                e.Color = Color.FromArgb(e.ColorCode);
            }
            return ls;
        }
        public async Task AddEventType(EventType evt)
        {
            await Init();

            var id = await db.InsertAsync(evt);
        }
        public async Task RemoveEventType(int id)
        {
            await Init();
            await db.DeleteAsync<EventType>(id);
        }
    }
}
