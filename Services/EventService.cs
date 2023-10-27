using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXMauiApp1.Models;
using SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DXMauiApp1.Services
{
    public class EventService : BaseSQLiteService
    {
        public async Task<Event> GetEventById(int id)
        {
            await Init();
            var query = await db.Table<Event>().FirstOrDefaultAsync(x => x.Id == id);

            return query;
        }
        public async Task<IEnumerable<Event>> GetMonthEvents(int month)
        {
            await Init();
            //var query = db.Table<Event>().Where(x => x.StartDateTime.Month == month);
            var events = await db.Table<Event>().ToListAsync();
            return events.Where(x=> x.StartDateTime.Month == month && x.EndDateTime.Month == month);
        }
        public async Task<IEnumerable<Event>> GetDateEvent(DateTime date)
        {
            await Init();

            //var query = db.Table<Event>().Where(x => x.StartDateTime <= date && x.EndDateTime >= date);
            var events = await db.Table<Event>().ToListAsync();
            return events.Where(x => x.StartDateTime.Date <= date.Date && x.EndDateTime.Date >= date.Date);
        }
        public async Task AddEvent(Event evt)
        {
            await Init();

            var id = await db.InsertAsync(evt);
        }
        public async Task RemoveEvent(int id)
        {
            await Init();
            await db.DeleteAsync<Event>(id);
        }
    }
}
