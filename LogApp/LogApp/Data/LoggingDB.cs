using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogApp
{
    public class LoggingDB
    {
        readonly SQLiteAsyncConnection database;

        public LoggingDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LogItem>().Wait();
        }

        public Task<List<LogItem>> GetItemsAsync()
        {
            return database.Table<LogItem>().ToListAsync();
        }

        public Task<List<LogItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<LogItem>("SELECT * FROM [LogItem]");
        }

        public Task<LogItem> GetItemAsync(int id)
        {
            return database.Table<LogItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(LogItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(LogItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}