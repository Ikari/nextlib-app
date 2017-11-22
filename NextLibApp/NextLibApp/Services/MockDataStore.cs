using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly:Xamarin.Forms.Dependency(typeof(NextLibApp.MockDataStore))]
namespace NextLibApp
{
    public class MockDataStore : IDataStore<Book>
    {
        List<Book> items;

        public MockDataStore()
        {
            items = new List<Book>();
            var mockItems = new List<Book>
            {
                new Book { Id = 1, Title = "Memórias de um Sargento de milícias", Description="Descrição do Livro" },
                new Book { Id = 2, Title = "Memórias de um Sargento de milícias", Description="Descrição do Livro" },
                new Book { Id = 3, Title = "Memórias de um Sargento de milícias", Description="Descrição do Livro" }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<int> SaveBookAsync(Book item)
        {
            items.Add(item);

            return await Task.FromResult(item.Id);
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            var _item = items.Where((Book arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(_item.Id);
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<List<Book>> GetBooksAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
