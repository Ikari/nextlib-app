using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextLibApp.Database
{    
    public class NextDatabase : IDataStore<Book>
    {
        readonly SQLiteAsyncConnection database;

        public NextDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Book>().Wait();
        }

        public async Task<List<Book>> GetBooksAsync(bool forceRefresh = false)
        {
            return await database.Table<Book>().ToListAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await database.FindAsync<Book>(id);
        }

        public async Task<int> SaveBookAsync(Book book)
        {
            if (book.Id != 0)
                return await database.UpdateAsync(book);

            return await database.InsertAsync(book);
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            return await database.DeleteAsync(database.FindAsync<Book>(id));
        }
    }
}
