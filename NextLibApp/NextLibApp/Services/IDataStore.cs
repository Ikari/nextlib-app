using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextLibApp
{
	public interface IDataStore<T>
	{
		Task<bool> AddBookAsync(T book);
		Task<bool> UpdateBookAsync(T book);
        Task<bool> DeleteBookAsync(int id);
		Task<T> GetBookAsync(int id);
		Task<IEnumerable<T>> GetBooksAsync(bool forceRefresh = false);
	}
}
