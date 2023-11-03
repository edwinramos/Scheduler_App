using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXMauiApp1.Models;
using SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DXMauiApp1.Services
{
    public class EventRepeatedService : BaseSQLiteService
    {
        public async Task<EventRepeated> GetEventRepeatedById(int id)
        {
            await Init();
            var query = await db.Table<EventRepeated>().FirstOrDefaultAsync(x => x.Id == id);

            return query;
        }
        public async Task<IEnumerable<EventRepeated>> GetEventRepeatedsByEvent(int eventId)
        {
            await Init();
            //var query = db.Table<EventRepeated>().Where(x => x.StartDateTime.Month == month);
            var EventRepeateds = await db.Table<EventRepeated>().ToListAsync();
            return EventRepeateds.Where(x => x.EventId == eventId);
        }
        public async Task SaveEventRepeated(EventRepeated evt)
        {
            await Init();
            if (evt.Id == 0)
                await db.InsertAsync(evt);
            else
                await db.UpdateAsync(evt);
        }
        public async Task RemoveEventRepeated(int id)
        {
            await Init();
            await db.DeleteAsync<EventRepeated>(id);
        }
    }
}
