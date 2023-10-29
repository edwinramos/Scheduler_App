using SQLite;
using DXMauiApp1.Models;
using System.Diagnostics;
using DevExpress.Maui.Scheduler;

namespace DXMauiApp1.Services
{
    public class BaseSQLiteService
    {
        protected SQLiteAsyncConnection db;
        public async Task Init()
        {
            try
            {
                if (db != null)
                    return;

                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "mydata.db");
                db = new SQLiteAsyncConnection(databasePath);
                await db.CreateTableAsync<Event>();
                await db.CreateTableAsync<EventType>();


                //Data Initialize
                if (!(await db.Table<EventType>().ToListAsync()).Any())
                {
                    var evt = new EventType();
                    evt.Caption = "None";
                    evt.ColorCode = "#c8cfca";
                    await db.InsertAsync(evt);

                    evt = new EventType();
                    evt.Caption = "Phone Call";
                    evt.ColorCode = "#dfcfe9";
                    await db.InsertAsync(evt);

                    evt = new EventType();
                    evt.Caption = "Vacation";
                    evt.ColorCode = "#c2f49d";
                    await db.InsertAsync(evt);

                    evt = new EventType();
                    evt.Caption = "Important";
                    evt.ColorCode = "#ed394e";
                    await db.InsertAsync(evt);

                    evt = new EventType();
                    evt.Caption = "Personal";
                    evt.ColorCode = "#eff23f";
                    await db.InsertAsync(evt);
                }

                if (!(await db.Table<Event>().ToListAsync()).Any())
                {
                    var evt = new Event();
                    evt.Title = "Successful Day";
                    evt.Description = "the day you're free";
                    evt.StartDateTime = DateTime.Now;
                    evt.EndDateTime = DateTime.Now.AddHours(1);
                    evt.Location = "Santo Domingo";
                    evt.EventTypeId = (await db.Table<EventType>().FirstOrDefaultAsync(x=>x.Caption == "Personal")).Id;
                    await db.InsertAsync(evt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while Init: {ex}");
            }
        }
    }
}
