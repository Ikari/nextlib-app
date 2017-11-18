using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly:Xamarin.Forms.Dependency(typeof(NextLibApp.MockDataStore))]
namespace NextLibApp
{
    public class MockDataStore : IDataStore<Book>
    {
        List<Book> Books;

        public MockDataStore()
        {
            Books = new List<Book>();
            var mockBooks = new List<Book>
            {
                new Book { Id = Guid.NewGuid().ToString(), Title = "First Book", Description="This is an Book description." },
                new Book { Id = Guid.NewGuid().ToString(), Title = "Second Book", Description="This is an Book description." },
                new Book { Id = Guid.NewGuid().ToString(), Title = "Third Book", Description="This is an Book description." },
            };

            foreach (var Book in mockBooks)
            {
                Books.Add(Book);
            }
        }

        public async Task<bool> AddBookAsync(Book Book)
        {
            Books.Add(Book);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateBookAsync(Book Book)
        {
            var _Book = Books.Where((Book arg) => arg.Id == Book.Id).FirstOrDefault();
            Books.Remove(_Book);
            Books.Add(Book);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            var _Book = Books.Where((Book arg) => arg.Id == id).FirstOrDefault();
            Books.Remove(_Book);

            return await Task.FromResult(true);
        }

        public async Task<Book> GetBookAsync(string id)
        {
            return await Task.FromResult(Books.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Books);
        }
    }
}
