using SQLite;
using DXMauiApp1.Models;
using System.Diagnostics;

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

                if (!(await db.Table<Event>().ToListAsync()).Any()) {
                    var evt = new Event();
                    evt.Title = "Successful Day";
                    evt.Description = "the day you're free";
                    evt.StartDateTime = DateTime.Now;
                    evt.EndDateTime = DateTime.Now.AddHours(1);
                    evt.IsRepeat = false;
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
