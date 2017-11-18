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

        public Task<List<Book>> GetBooksAsync()
        {
            return database.Table<Book>().ToListAsync();
        }

        public Task<Book> GetBookAsync(int id)
        {
            return database.FindAsync<Book>(id);
        }

        public Task<int> SaveBookAsync(Book book)
        {
            if (book.Id != 0)
                return database.UpdateAsync(book);

            return database.InsertAsync(book);
        }

        public Task<int> DeleteBookAsync(int id)
        {
            return database.DeleteAsync(database.FindAsync<Book>(id));
        }
    }
}
